var builder = DistributedApplication.CreateBuilder(args);

var pgServer = builder.AddPostgres("pg-server")
    .WithLifetime(ContainerLifetime.Persistent);

var showsDatabase = pgServer.AddDatabase("shows");


builder.AddProject<Projects.Shows_Api>("shows-api")
    .WithReference(showsDatabase)
    .WaitFor(showsDatabase);

builder.Build().Run();
