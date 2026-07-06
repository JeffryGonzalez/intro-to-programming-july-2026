
// Top level statements - a file (Program.cs) with some code gets compiled into Program.Main(string[] args);
var builder = WebApplication.CreateBuilder(args);

// Configuring services. What are services? Some code that own some data and the process for that data.

var app = builder.Build();

// Http "Pipeline" - how individual requests and responses

app.Run();