using CoreBusiness.Entities.ToDo;

namespace UnitTests.CoreBusiness.Entities;

public class ToDoCreation
{
    private readonly string title = "Test Title";
    private readonly string description = "Test Description";
    private readonly ToDoStatus status = ToDoStatus.NotStarted;

    [Fact]
    public void SuccessfullCreation()
    {
        ToDo item = new(title,status,description);
        Assert.Equal(title, item.Title);
        Assert.Equal(status, item.Status);
        Assert.Equal(description, item.Description);
    }

    [Fact]
    public void SetTitle()
    {
        ToDo item = new(title, status, description);
        string newTitlte = "New Title";
        item.SetTitle(newTitlte);
        Assert.Equal(newTitlte, item.Title);
    }


    [Fact]
    public void PreventEmptyTitle()
    {
        string emptyTitle = "";
        Assert.Throws<ArgumentException>(() => new ToDo(emptyTitle, status, description));
    }
}