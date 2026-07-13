namespace Shows.Api.Shows;

public interface IProvideShowsData
{
    Task<ShowSummary> AddShowAsync(ShowCreateRequest request);
    Task<IReadOnlyList<ShowSummary>> GetAllShowsAsync(CancellationToken token = default);
    Task<ShowSummary?> GetShowByIdAsync(Guid id);
}