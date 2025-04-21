using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Entities.ToDo;

internal class ToDo
{
    public string Title { get;private set; }
    public string? Description { get;private set; }
    public ToDoStatus Status { get;private set; }

#pragma warning disable CS8618 // Required by Entity Framework
    private ToDo() { }
    public ToDo(string title, ToDoStatus status, string? description = null)
    {
        SetTitle(title);
        SetStatus(status);
        SetDescription(description);
    }


    public void SetTitle(string title)
    {
        Guard.Against.NullOrEmpty(title, nameof(title));
        Title = title;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }

    public void SetStatus(ToDoStatus status)
    {
        Guard.Against.Null(status);
        Status = status;
    }
}


public enum ToDoStatus
{
    NotStarted,
    InProgress,
    Completed
}