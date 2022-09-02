using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entityframeworkproject;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TaskContext> (p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TaskContext> (builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async([FromServices] TaskContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory:" + dbContext.Database.IsInMemory());
});

app.Run();
