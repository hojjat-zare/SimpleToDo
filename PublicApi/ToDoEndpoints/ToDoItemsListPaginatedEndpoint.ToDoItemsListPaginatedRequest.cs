using CoreBusiness.Entities.ToDo;

namespace PublicApi.ToDoEndpoints;

public class ToDoItemsListPaginatedRequest : BaseRequest
{
    public ToDoItemsListPaginatedRequest(string? description, string? title, ToDoStatus? status, int pageSize = 0, int pageIndex = 0)
    {
        PageSize = pageSize;
        PageIndex = pageIndex;
        Description = description;
        Title = title;
        Status = status;
    }

    public int PageSize { get; init; }
    public int PageIndex { get; init; }
    public string? Description { get; init; }
    public string? Title { get; init; }
    public ToDoStatus? Status{ get; init; }
}
