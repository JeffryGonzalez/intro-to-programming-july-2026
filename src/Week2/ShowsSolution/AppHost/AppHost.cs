using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);
var scalar = builder.AddScalarApiReference(options =>
{
    options.PreferHttpsEndpoint = true;
    options.AllowSelfSignedCertificates = true;
}).WithLifetime(ContainerLifetime.Persistent);

var pgServer = builder.AddPostgres("pg")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin();

var showsDb = pgServer.AddDatabase("shows");


// My Stuff Below

var showsApi = builder.AddProject<Projects.Shows_Api>("shows-api")
    .WaitFor(showsDb)
    .WithReference(showsDb)
    .WaitFor(scalar);

scalar.WithApiReference(showsApi);

builder.Build().Run();
