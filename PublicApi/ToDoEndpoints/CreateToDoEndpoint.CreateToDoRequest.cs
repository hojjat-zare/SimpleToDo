using CoreBusiness.Entities.ToDo;

namespace PublicApi.ToDoEndpoints;

public class CreateToDoRequest : BaseRequest
{
    public CreateToDoRequest(string? description, string title, ToDoStatus status)
    {
        Description = description;
        Title = title;
        Status = status;
    }


    public string? Description { get; init; }

    public string Title { get; init; }

    public ToDoStatus Status { get; init; }
}
