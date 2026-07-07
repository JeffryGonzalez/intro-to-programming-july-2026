
// Top level statements - a file (Program.cs) with some code gets compiled into Program.Main(string[] args);



using Shows.Api.Shows;

var builder = WebApplication.CreateBuilder(args);

// Configuring services. What are services? Some code that own some data and the process for that data.
builder.Services.AddScoped<ShowsData>();

var app = builder.Build();

// Http "Pipeline" - how individual requests and responses

// Hey, if anyone does a GET request on the resource named /shows - run this function 
app.MapGet("/shows", async (ShowsData service, CancellationToken token) => 
    await service.GetAllShowsAsync(token));

app.MapPost("/shows", () => Results.StatusCode(201));

app.Run(); // not able to receive requests until you are here.