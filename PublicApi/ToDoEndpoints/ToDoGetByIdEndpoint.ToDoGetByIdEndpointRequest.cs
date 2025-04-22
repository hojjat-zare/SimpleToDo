namespace PublicApi.ToDoEndpoints;

public class ToDoGetByIdEndpointRequest : BaseRequest
{
    public ToDoGetByIdEndpointRequest(int id)
    {
        Id = id;
    }

    public int Id { get; init; }
}