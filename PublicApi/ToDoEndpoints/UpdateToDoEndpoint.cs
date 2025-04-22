using CoreBusiness.Entities.ToDo;
using CoreBusiness.Interfaces;
using FluentValidation;
using MinimalApi.Endpoint;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.ToDoEndpoints;

public class UpdateToDoEndpoint : IEndpoint<IResult, UpdateToDoRequest, IRepository<ToDo>, IValidator<UpdateToDoRequest>>
{
    public UpdateToDoEndpoint()
    {
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/todos",
            async (UpdateToDoRequest request, IRepository<ToDo> itemRepository, IValidator<UpdateToDoRequest> validator) =>
            {
                return await HandleAsync(request, itemRepository,validator);
            })
            .Produces<UpdateToDoResponse>()
            .WithTags("TodoEndpoints");
    }



    public async Task<IResult> HandleAsync(UpdateToDoRequest request, IRepository<ToDo> ToDoRepository, IValidator<UpdateToDoRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));


        var response = new UpdateToDoResponse(request.CorrelationId());

        var item = await ToDoRepository.GetByIdAsync(request.Id);
        if (item is null)
            return Results.NotFound();

        item.SetDescription(request.Description);
        item.SetTitle(request.Title);
        item.SetStatus(request.Status);

        await ToDoRepository.UpdateAsync(item);

        response.ToDo = new ToDoDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Status = item.Status
        };
        return Results.Ok(response);
    }
}