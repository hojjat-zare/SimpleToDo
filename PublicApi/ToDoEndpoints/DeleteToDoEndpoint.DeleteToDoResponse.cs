namespace PublicApi.ToDoEndpoints;

public class DeleteToDoResponse : BaseResponse
{
    public DeleteToDoResponse(Guid correlationId) : base(correlationId)
    {
    }
    public DeleteToDoResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
