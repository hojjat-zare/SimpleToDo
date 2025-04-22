namespace PublicApi.ToDoEndpoints;


#pragma warning disable CS8618
public class UpdateToDoResponse : BaseResponse
{
    public UpdateToDoResponse(Guid correlationId) : base(correlationId)
    {
    }
    public UpdateToDoResponse()
    {
    }

    public ToDoDto ToDo { get; set; }
}
