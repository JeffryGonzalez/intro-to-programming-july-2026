namespace Shows.Api.Shows;

public class SqlServerDataProvider : IProvideShowsData
{
    public Task<ShowSummary> AddShowAsync(ShowCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ShowSummary>> GetAllShowsAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<ShowSummary?> GetShowByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
