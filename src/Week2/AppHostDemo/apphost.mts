// Aspire TypeScript AppHost
// For more information, see: https://aspire.dev

import { ContainerLifetime, createBuilder } from './.aspire/modules/aspire.mjs';

const builder = await createBuilder();

// Add your resources here, for example:
// const redis = await builder.addContainer("cache", "redis:latest");
// const postgres = await builder.addPostgres("db");


const k8s = await builder.addKubernetesEnvironment("shows-k8s");
var pg = await builder.addPostgres("pg-server")
.withLifetime(ContainerLifetime.Persistent);

var showsDb = await pg.addDatabase("shows");

// The Api
var showsApi = await builder.addContainer("api", "jeffrygonzalez/shows-api:v2.1")
.withLifetime(ContainerLifetime.Persistent)
.withReference(showsDb)
.withHttpEndpoint({
    port: 1337,
    targetPort: 8080
})
.waitFor(showsDb);

const frontend = await builder.addContainer("frontend", "jeffrygonzalez/shows-frontend:v1")
.withHttpEndpoint({
    port: 1338,
    targetPort:80
})
.waitFor(showsApi);


const gw = await builder.addYarp("gateway")
.withChildRelationship(frontend)
.withChildRelationship(showsApi)
.withHostPort({port: 4200})
.withLifetime(ContainerLifetime.Persistent);

await gw.withConfiguration(async (yarp) => {
    await yarp.addRoute("/{**catchall}", frontend.getEndpoint('http'))
    await yarp.addRoute("/api/{**catchall}", showsApi.getEndpoint('http'))
})
await builder.build().run();