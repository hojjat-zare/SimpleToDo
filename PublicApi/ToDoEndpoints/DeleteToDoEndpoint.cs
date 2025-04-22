using CoreBusiness.Entities.ToDo;
using CoreBusiness.Interfaces;
using MinimalApi.Endpoint;

namespace PublicApi.ToDoEndpoints;

public class DeleteToDoEndpoint : IEndpoint<IResult, DeleteToDoRequest, IRepository<ToDo>>
{
    public DeleteToDoEndpoint()
    {
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/todos/{Id}",
            async (int Id, IRepository<ToDo> itemRepository) =>
            {
                return await HandleAsync(new DeleteToDoRequest(Id), itemRepository);
            })
            .Produces<DeleteToDoResponse>()
            .WithTags("TodoEndpoints");
    }



    public async Task<IResult> HandleAsync(DeleteToDoRequest request, IRepository<ToDo> ToDoRepository)
    {
        var response = new DeleteToDoResponse(request.CorrelationId());

        var item = await ToDoRepository.GetByIdAsync(request.Id);
        if (item is null)
            return Results.NotFound();

        await ToDoRepository.DeleteAsync(item);
        return Results.Ok(response);
    }
}