using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickedWebAPI.Models.Entities
{
    public class App1_Subcategoria
    {
        [Key]
        public int Id { get; set; }
        public string? Subcategoria { get; set; }
        public int Categoria_Id { get; set; }

        // [ForeignKey("BlogForeignKey")]
        // public App1_Categoria Categorias { get; set; } 
    }
}
