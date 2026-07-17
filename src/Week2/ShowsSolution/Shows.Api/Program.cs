using Marten;
using Shows.Api.Shows;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// appsettings.json - "ConnectionStrings": { "shows": "..." }}
// appsettings.{Environment}.json -- same deal.
// "secrets" - we don't really use this much, tbh.
// Environment Variables ConnectionStrings__shows 
// Command line arguments - can't even remember how to do this.

var connectionString = builder.Configuration.GetConnectionString("shows") ??
    throw new Exception("No Connection String Provided");

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    options.Schema.For<ShowEntity>().Index(s => s.Title);
}).UseLightweightSessions();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // add endpoint that you can use to get the JSON documentation
    // Microsoft plays it safe and by default, only available during development.
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();


// reflection to find all the controller classes, read their attributes,
// and create the route table (lookup) that way.
app.MapControllers(); 
app.MapGet("/status", (TimeProvider p) => $"Looks good at " + p.GetUtcNow());
app.Run();
