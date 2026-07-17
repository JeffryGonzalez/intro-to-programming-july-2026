
// Top level statements - a file (Program.cs) with some code gets compiled into Program.Main(string[] args);



using Marten;
using Shows.Api.Shows;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("shows") ?? throw new Exception("Need a Connection String!");

builder.AddServiceDefaults();

builder.Services.AddValidation();

builder.AddNpgsqlDataSource("shows"); // sets up the connection to the database called "shows", with OTEL.

builder.Services.AddHttpClient<InventoryNotification>(client =>
{
    var addy = builder.Configuration.GetValue<string>("notificationApi") ?? throw new Exception("need the url");
    client.BaseAddress = new Uri(addy);
});

builder.Services.AddScoped<INotifyInventoryControl>(sp =>
{
    // don't create a new instance, use the "service provider" to return the one configured above.
    return sp.GetRequiredService<InventoryNotification>();
});
// we will now have a service we can inject (like ShowsData) called IDocumentSession - use that to access the database.
builder.Services.AddMarten(options => // Configures the IDocumentSession so it can be injected anywhere in this application.
{
    // stuff coming here later.
}).UseNpgsqlDataSource().UseLightweightSessions();

// Configuring services. What are services? Some code that own some data and the process for that data.

// Pretty much anything that has to do with a user, including users activity in a database, should MUST be "scoped"
builder.Services.AddScoped<IProvideShowsData, ShowsData>(); // Saying we will provide this service to anything that injects it.
//builder.Services.AddScoped<IProvideShowsData,SqlServerDataProvider>();

var app = builder.Build();

// Http "Pipeline" - how individual requests and responses

// Hey, if anyone does a GET request on the resource named /shows - run this function 

// Poor Person's Feature Toggle (feature flag)


app.MapShow();

app.MapDefaultEndpoints(); // service defaults, things like health checks, etc.

app.Run(); // not able to receive requests until you are here.

