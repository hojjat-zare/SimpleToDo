using CoreBusiness.Entities.ToDo;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.ToDoEndpoints;

public class UpdateToDoRequest : BaseRequest
{
    public UpdateToDoRequest(int id,string? description, string title, ToDoStatus status)
    {
        Id = id;
        Description = description;
        Title = title;
        Status = status;
    }

    public int Id { get; set; }

    public string? Description { get; init; }

    public string Title { get; init; }

    public ToDoStatus Status { get; init; }
}
