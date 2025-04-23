using CoreBusiness.Interfaces;
using CoreBusiness.Entities.ToDo;
using MinimalApi.Endpoint;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness.Specification;
using AutoMapper;

namespace PublicApi.ToDoEndpoints;

public class ToDoItemsListPaginatedEndpoint(IMapper mapper) :
    IEndpoint<IResult, ToDoItemsListPaginatedRequest, IReadRepository<ToDo>>
{

    private readonly IMapper _mapper = mapper;

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/todos",
            async ([AsParameters]ToDoItemsListPaginatedRequest request, IReadRepository<ToDo> itemRepository) =>
            {
                return await HandleAsync(request, itemRepository);
            })
            .Produces<ToDoItemsListPaginatedResponse>()
            .WithTags("TodoEndpoints");
    }

    public async Task<IResult> HandleAsync(ToDoItemsListPaginatedRequest request, IReadRepository<ToDo> repository)
    {
        var response = new ToDoItemsListPaginatedResponse(request.CorrelationId());

        var filter = new ToDoFilterSpecification(
            request.Description,
            request.Title,
            request.Status);

        var totalItems = await repository.CountAsync(filter);


        var paginatedSpec = new ToDoFilterPaginatedSpecification(
            request.PageSize,
            request.PageIndex,
            request.Description,
            request.Title,
            request.Status);


        var items = await repository
            .ListAsync(paginatedSpec);

        response.ToDos = _mapper.Map<List<ToDoDto>>(items);

        response.SetPageCount(totalItems, request.PageSize);

        return Results.Ok(response);
    }
}