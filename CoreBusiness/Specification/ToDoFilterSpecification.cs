using Ardalis.Specification;
using CoreBusiness.Entities.ToDo;

namespace CoreBusiness.Specification;

public class ToDoFilterSpecification : Specification<ToDo>
{

    public ToDoFilterSpecification(string? description, string? title, ToDoStatus? status)
    {
        Query.Where( t =>
            (string.IsNullOrEmpty(description) || t.Description != null && t.Description.Contains(description)) &&
            (string.IsNullOrEmpty(title) || t.Title.Contains(title)) &&
            (!status.HasValue || t.Status == status)
        );
    }
}
