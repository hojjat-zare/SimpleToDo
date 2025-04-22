namespace PublicApi.ToDoEndpoints;

public class DeleteToDoRequest : BaseRequest
{
    public int Id { get; init; }

    public DeleteToDoRequest(int id)
    {
        Id = id;
    }
}
