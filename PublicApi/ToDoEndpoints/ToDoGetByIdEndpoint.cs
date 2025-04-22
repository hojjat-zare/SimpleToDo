using CoreBusiness.Entities.ToDo;
using CoreBusiness.Interfaces;
using MinimalApi.Endpoint;

namespace PublicApi.ToDoEndpoints;

public class ToDoGetByIdEndpoint : IEndpoint<IResult, ToDoGetByIdEndpointRequest, IRepository<ToDo>>
{
    public ToDoGetByIdEndpoint()
    {
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/todos/{Id}",
            async (int Id, IRepository<ToDo> itemRepository) =>
            {
                return await HandleAsync(new ToDoGetByIdEndpointRequest(Id), itemRepository);
            })
            .Produces<ToDoGetByIdEndpointResponse>()
            .WithTags("TodoEndpoints");
    }



    public async Task<IResult> HandleAsync(ToDoGetByIdEndpointRequest request, IRepository<ToDo> ToDoRepository)
    {
        var response = new ToDoGetByIdEndpointResponse(request.CorrelationId());

        var item = await ToDoRepository.GetByIdAsync(request.Id);
        if (item is null)
            return Results.NotFound();

        response.ToDo = new ()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Status = item.Status
        };
        return Results.Ok(response);
    }
}