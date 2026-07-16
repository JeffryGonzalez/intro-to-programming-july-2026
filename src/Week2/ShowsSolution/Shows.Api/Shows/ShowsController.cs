
using Marten;
using System.ComponentModel.DataAnnotations;

namespace Shows.Api.Shows;


[ApiController] // This is also going to do some validation stuff, so a bit weird.
public class ShowsController(IDocumentSession session) : ControllerBase
{

    // General rule of thumb about cancellation tokens:
    // Use them ALWAYS for safe operations (GET requests, basically)
    // Pass the token 
    [HttpGet("/api/shows")]
    public async Task<ActionResult> GetAllShowsAsync(CancellationToken token, [FromQuery] string title = "all")
    {
        // look up the shows, etc.
        var part1 = session.Query<ShowEntity>();// query the database for all show entities.

        // part of the query
           




        if (title != "all")
        {
          part1= (Marten.Linq.IMartenQueryable<ShowEntity>)part1.Where(s => s.Title == title); 
            // if there is a query string argument for title that isn't "all", add a "where clause" to the query
        
        }
        part1
            .OrderByDescending(s => s.CreatedOn)
            .Select(s => new ShowItem
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                StreamingServices = s.StreamingServices
            });
            
        var response = await part1.ToListAsync(token); // hits the database HERE.
        return Ok(response);
    }

    [HttpPost("/api/shows")]
    public async Task<ActionResult> AddShowAsync([FromBody] ShowCreate request, TimeProvider clock)
    {
        // Do not string concatenate SQL. 
        var entity = new ShowEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            StreamingServices = request.StreamingServices,
            CreatedOn = clock.GetUtcNow()
        };
        session.Store(entity);
        await session.SaveChangesAsync();
        var response = new ShowItem
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StreamingServices = entity.StreamingServices
        };
        return Ok(response);
    }



}

public record ShowItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] StreamingServices { get; set; } = [];
}

public record ShowCreate
{
    [MinLength(5)]
    public required string Title { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public string[] StreamingServices { get; set; } = [];
}

public class ShowEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] StreamingServices { get; set; } = [];
    public DateTimeOffset CreatedOn { get; set; }
}