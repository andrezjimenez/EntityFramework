using System.ComponentModel.DataAnnotations;

namespace Entityframeworkproject.Models;

public class Category{

    // [Key]
    public Guid CategoryId {get; set;}

    // [Required]
    // [MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    
    public int Peso {get; set;}

    public virtual ICollection<Tarea> Tasks {get;set;}
}
