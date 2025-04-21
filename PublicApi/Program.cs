using CoreBusiness.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

bool useOnlyInMemoryDatabase = false;
if (builder.Configuration["UseOnlyInMemoryDatabase"] != null)
{
    useOnlyInMemoryDatabase = bool.Parse(builder.Configuration["UseOnlyInMemoryDatabase"]!);
}

if (useOnlyInMemoryDatabase)
{
    builder.Services.AddDbContext<ToDoContext>(c =>
       c.UseInMemoryDatabase("SimpleToDoDb"));
}
else
{
    builder.Services.AddDbContext<ToDoContext>(c =>
        c.UseSqlServer(builder.Configuration.GetConnectionString("ToDoContext")));
}


builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));



// Add builder.Services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();