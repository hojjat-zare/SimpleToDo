using CoreBusiness.Entities.ToDo;

namespace PublicApi.ToDoEndpoints;

public class ToDoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ToDoStatus Status { get; set; }
}
