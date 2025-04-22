using Azure.Core;
using Azure;

namespace PublicApi.ToDoEndpoints;

public class ToDoItemsListPaginatedResponse : BaseResponse
{
    public ToDoItemsListPaginatedResponse()
    {
        
    }

    public ToDoItemsListPaginatedResponse(Guid correlationId) : base(correlationId)
    {
        
    }

    public List<ToDoDto> ToDos { get; set; } = [];

    public int PageCount { get; set; }

    internal void SetPageCount(int totalItems, int pageSize)
    {
        if (pageSize > 0)
        {
            PageCount = int.Parse(Math.Ceiling((decimal)totalItems / pageSize).ToString());
        }
        else
        {
            PageCount = totalItems > 0 ? 1 : 0;
        }
    }
}
