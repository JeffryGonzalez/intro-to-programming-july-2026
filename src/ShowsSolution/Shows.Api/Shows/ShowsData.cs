using System.Runtime.CompilerServices;

namespace Shows.Api.Shows;


// The code that is responsible for the data for shows, and all the process around that.
// This is a Service!

public class ShowsData
{
    // TLDR on Async/Await: If you are going across a network, filesystem, other apis, databases, etc.
    // You must use async/await
    public async Task<IReadOnlyList<ShowSummary>> GetAllShowsAsync(CancellationToken token = default)
    {
        // todo: connect to the database, run a query to get all the shows, and return that list.
        return [];
    }
}




public record ShowSummary(Guid Id, string Title);

