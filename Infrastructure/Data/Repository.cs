using Ardalis.Specification.EntityFrameworkCore;
using CoreBusiness.Interfaces;




namespace Infrastructure.Data;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(ToDoContext dbContext) : base(dbContext)
    {
    }
}
