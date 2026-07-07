
using Alba;
using Shows.Api.Shows;

namespace Shows.Tests.Shows;

public class AddingShows
{
    // I want to send an http request to the server to add a show,
    // and if it succeeds, when i get the list of shows, the show I just
    // added is in that list.


    [Fact]
    public async Task CanAddAShowToTheInventory()
    {
        var showToAdd = new { title = "Twin Peaks, the Return" };
        var host = await AlbaHost.For<Program>();
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
