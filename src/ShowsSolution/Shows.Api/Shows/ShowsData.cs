using Marten;
using System.Runtime.CompilerServices;

namespace Shows.Api.Shows;


// The code that is responsible for the data for shows, and all the process around that.
// This is a Service!

public class ShowsData(IDocumentSession session)
{
    // TLDR on Async/Await: If you are going across a network, filesystem, other apis, databases, etc.
    // You must use async/await
    public async Task<IReadOnlyList<ShowSummary>> GetAllShowsAsync(CancellationToken token = default)
    {
        // Language Integrated Query (LINQ) - "Homoiconicity" in a OOP Language? Yep.
        var results = await session.Query<ShowEntity>()
            .OrderBy(s => s.Added)
            .Select(s => new ShowSummary(s.Id, s.Title))
            .ToListAsync(token);
        return results;
    }

    public async Task<ShowSummary> AddShowAsync(ShowCreateRequest request)
    {
        // open a connection to a database, run a SQL insert statement, save it whatever.
        var entity = new ShowEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Added = DateTimeOffset.Now
        };
        // ??
        session.Store(entity);
        await session.SaveChangesAsync(); // do the work.
        return new ShowSummary(entity.Id, entity.Title);
        
    }

    public async Task<ShowSummary?> GetShowByIdAsync(Guid id)
    {
        return await session.Query<ShowEntity>()
            .Where(s => s.Id == id)
            .Select(s => new ShowSummary(s.Id, s.Title))
            .FirstAsync(); // 
      
    }
}

public class ShowEntity
{
    public Guid Id { get; set; }
    public string Title { get; set;  } = string.Empty;
    public DateTimeOffset Added { get; set; }
}
