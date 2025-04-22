namespace PublicApi.ToDoEndpoints;


#pragma warning disable CS8618
public class ToDoGetByIdEndpointResponse : BaseResponse
{
    public ToDoGetByIdEndpointResponse(Guid correlationId) : base(correlationId)
    {
    }
    public ToDoGetByIdEndpointResponse()
    {
    }

    public ToDoDto ToDo { get; set; }
}
