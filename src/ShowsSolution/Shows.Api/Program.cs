
// Top level statements - a file (Program.cs) with some code gets compiled into Program.Main(string[] args);



using Marten;
using Shows.Api.Shows;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

builder.AddNpgsqlDataSource("shows"); // sets up the connection to the database called "shows", with OTEL.


// we will now have a service we can inject (like ShowsData) called IDocumentSession - use that to access the database.
builder.Services.AddMarten(options =>
{
    // stuff coming here later.
}).UseNpgsqlDataSource().UseLightweightSessions();

// Configuring services. What are services? Some code that own some data and the process for that data.
builder.Services.AddScoped<ShowsData>();

var app = builder.Build();

// Http "Pipeline" - how individual requests and responses

// Hey, if anyone does a GET request on the resource named /shows - run this function 

// Poor Person's Feature Toggle (feature flag)


app.MapShow();


app.Run(); // not able to receive requests until you are here.

