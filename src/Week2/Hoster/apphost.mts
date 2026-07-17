// Aspire TypeScript AppHost
// For more information, see: https://aspire.dev

import { createBuilder } from './.aspire/modules/aspire.mjs';

const builder = await createBuilder();

// Add your resources here, for example:
// const redis = await builder.addContainer("cache", "redis:latest");
// const postgres = await builder.addPostgres("db");
const k8s = await builder.addKubernetesEnvironment("k8s");

const postgres = await builder.addPostgres("pg");

const db = await postgres.addDatabase("shows");

const showsApi = await builder.addContainer("shows-api", "jeffrygonzalez/ss:0.01")
.withHttpEndpoint({
    port: 8080,
    targetPort: 8080
})
.waitFor(db)
.withReference(db)
.withComputeEnvironment(k8s);

const frontend = await builder.addContainer("frontend", "jeffrygonzalez/shows-frontend:0.01")
.withHttpEndpoint({
    port: 8090,
    targetPort: 80
})
.waitFor(showsApi)
.withComputeEnvironment(k8s);

const gw = await builder.addYarp("gateway")
.withHostPort({ port: 9090});

await gw.withConfiguration(async (yarp) => {
    await yarp.addRoute('/{**catchall}', frontend.getEndpoint('http'));
    await yarp.addRoute('/api/{**catchall}', showsApi.getEndpoint('http'));
});
await builder.build().run();