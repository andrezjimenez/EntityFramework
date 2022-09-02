using Microsoft.EntityFrameworkCore;
using Entityframeworkproject.Models;


namespace Entityframeworkproject;

public class TaskContext: DbContext
{
    public DbSet<Category> Categorys {get;set;}

    public DbSet<Tarea> Tasks {get;set;}

    public TaskContext(DbContextOptions<TaskContext> options): base(options){}

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>{
            category.ToTable("Categoria");
            category.HasKey(p=> p.CategoryId);
            
            category.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            category.Property(p => p.Descripcion);

        }) ;

        modelBuilder.Entity<Tarea>(task => {
            task.ToTable("Tarea");
            task.HasKey(t=> t.TareaId);

            task.HasOne(t => t.Categoria).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);

            task.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
            task.Property(t => t.Descripcion).IsRequired().HasMaxLength(250);

            // task.Property (t => t.Resumen).
        });
        
    }
     
}