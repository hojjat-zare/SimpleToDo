using AutoMapper;
using CoreBusiness.Entities.ToDo;
using PublicApi.ToDoEndpoints;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDo, ToDoDto>();
    }
}
