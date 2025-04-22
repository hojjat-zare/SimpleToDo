using CoreBusiness.Entities.ToDo;
using CoreBusiness.Interfaces;
using FluentValidation;
using MinimalApi.Endpoint;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.ToDoEndpoints;

public class CreateToDoEndpoint : IEndpoint<IResult, CreateToDoRequest, IRepository<ToDo>, IValidator<CreateToDoRequest>>
{
    public CreateToDoEndpoint()
    {
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("api/todos",
            async (CreateToDoRequest request, IRepository<ToDo> itemRepository, IValidator<CreateToDoRequest> validator) =>
            {
                return await HandleAsync(request, itemRepository, validator);
            })
            .Produces<CreateToDoResponse>()
            .WithTags("TodoEndpoints");
    }



    public async Task<IResult> HandleAsync(CreateToDoRequest request, IRepository<ToDo> ToDoRepository, IValidator<CreateToDoRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

        var response = new CreateToDoResponse(request.CorrelationId());

        ToDo item = new(request.Title, request.Status, request.Description);

        item = await ToDoRepository.AddAsync(item);

        response.ToDo = new ToDoDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Status = item.Status
        };
        return Results.Created($"api/todos/{response.ToDo.Id}", response);
    }
}