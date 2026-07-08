
using Alba;
using Microsoft.AspNetCore.Hosting;
using Shows.Api.Shows;
using Testcontainers.PostgreSql;

namespace Shows.Tests.Shows;

public class AddingShows : IAsyncLifetime
{
    // I want to send an http request to the server to add a show,
    // and if it succeeds, when i get the list of shows, the show I just
    // added is in that list.
    private IAlbaHost host = null!;
    private PostgreSqlContainer _pgContainer = null!;
    

    [Fact]
    public async Task CanAddAShowToTheInventory()
    {
        // a sample of a show that we want to add
        var showToAdd = new { title = "Twin Peaks, the Return" };
        // Start up the API
       
        // On the API...
        var result = await host.Scenario(api =>
        {

            api.Post.Json(showToAdd).ToUrl("/shows");
            api.StatusCodeShouldBe(201);

        });

        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url("/shows");
            api.StatusCodeShouldBeOk();
        });

        // that getResponse should have the show "Twin Peaks, the Return";
        var dataFromGet = getResponse.ReadAsJson<IReadOnlyList<ShowSummary>>();
        Assert.NotNull(dataFromGet);
        Assert.True(dataFromGet.Any(), "No Data - bummer");
        // assert that twin peaks is in there

        var hasTwinPeaks = dataFromGet.Any(s => s.Title == "Twin Peaks, the Return");

        Assert.True(hasTwinPeaks);
    }

    public async Task InitializeAsync()
    {
        _pgContainer = new PostgreSqlBuilder("postgres:18.3")
              .Build();
        await _pgContainer.StartAsync();
        host = await AlbaHost.For<Program>(config =>
        {
            config.UseSetting("ConnectionStrings:shows",
                _pgContainer.GetConnectionString());
            config.ConfigureServices(sp =>
            {
            // replace the service that calls the reminder service
            // with a fake version that blows up.
          
            });
            // todo: change the config
        });
    }
    public async Task DisposeAsync()
    {
        await host.DisposeAsync();
        await _pgContainer.DisposeAsync();
    }




    //[Fact]
    //public async Task ManualWay()
    //{
    //    var client = new HttpClient();
    //    client.BaseAddress = new Uri("https://localhost:1337");

    //    var response = await client.GetAsync("/shows");

    //    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    //}


}
