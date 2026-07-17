namespace Shows.Api.Shows;

public interface INotifyInventoryControl
{
    Task NotifyInventoryControlOfNewShow(string title);
}

public class InventoryNotification(HttpClient client) : INotifyInventoryControl
{

    public async Task NotifyInventoryControlOfNewShow(string title)
    {
        // call another API, interact with another service, whatever.
       
        await client.PostAsJsonAsync("/notifications", new { title });
    }
}
