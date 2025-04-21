using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness.Entities.ToDo;

namespace Infrastructure.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
    }

    public DbSet<ToDo> ToDos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoContext).Assembly);
    }
}