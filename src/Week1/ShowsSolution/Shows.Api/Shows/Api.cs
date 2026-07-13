using Microsoft.AspNetCore.SignalR;

namespace Shows.Api.Shows;

public static class Api
{
    extension(IEndpointRouteBuilder routes)
    {
        public IEndpointRouteBuilder MapShow()
        {
            routes.MapGet("/shows", async (IProvideShowsData service, CancellationToken token) =>
                await service.GetAllShowsAsync(token));

            // GET /shows/83c2019d-7e33-4abe-9751-7703a73a03f5
            routes.MapGet("/shows/{id:guid}", async (Guid id, IProvideShowsData service) =>
            {
                ShowSummary? response = await service.GetShowByIdAsync(id);

                if(response is null)
                {
                    return Results.NotFound();
                } else
                {
                    return Results.Ok(response);
                }
               
            });

            routes.MapPost("/shows", async (ShowCreateRequest request, IProvideShowsData service) =>
            {

                ShowSummary response = await service.AddShowAsync(request); // WTCYWYH (Write the code you wish you had)
                
                return Results.Created($"/shows/{response.Id}", response);
            });
            return routes;
        }
    }
}

