using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entityframeworkproject;
using Entityframeworkproject.Models;


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

app.MapGet("/api/tareas", async([FromServices] TaskContext dbContext  )=>
    {
        return Results.Ok(dbContext.Tasks.Include(p =>  p.Categoria).Where(p => p.PrioridadTarea == Entityframeworkproject.Models.Priority.Medium ));
    });

app.MapPost("/api/tareas", async([FromServices] TaskContext dbContext , [FromBody] Tarea tarea )=>
    {
        tarea.TareaId = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        await dbContext.AddAsync(tarea);
        // await dbContext.Tarea.AddRangeAsync(tarea); // Esta es otra manera de ejecutarlo
        await dbContext.SaveChangesAsync();
        return Results.Ok();
      
    });

app.MapPut("/api/tareas/update/{id}", async([FromServices] TaskContext dbContext , [FromBody] Tarea tarea, [FromRoute] Guid id)=>
    {
        var tareaActual = dbContext.Tasks.Find(id);

        if(tareaActual != null){

            tareaActual.CategoryId = tarea.CategoryId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Descripcion = tarea.Descripcion;

            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }

        return Results.NotFound();
      
    });


app.Run();
