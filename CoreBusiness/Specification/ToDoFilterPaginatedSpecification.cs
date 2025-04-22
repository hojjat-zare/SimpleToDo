using Ardalis.Specification;
using CoreBusiness.Entities.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Specification;

public class ToDoFilterPaginatedSpecification : Specification<ToDo>
{
    public ToDoFilterPaginatedSpecification(int pageSize, int pageIndex, string? description, string? title, ToDoStatus? status)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query.Where(t =>
                (string.IsNullOrEmpty(description) || t.Description != null && t.Description.Contains(description)) &&
                (string.IsNullOrEmpty(title) || t.Title.Contains(title)) &&
                (!status.HasValue || t.Status == status)
            )
            .OrderBy(t => t.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize);
    }
}
