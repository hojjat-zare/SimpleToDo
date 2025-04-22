namespace PublicApi.ToDoEndpoints;



#pragma warning disable CS8618
public class CreateToDoResponse : BaseResponse
{
    public CreateToDoResponse(Guid correlationId) : base(correlationId) { }

    public CreateToDoResponse()
    {
        
    }

    public ToDoDto ToDo { get; set; }

}
