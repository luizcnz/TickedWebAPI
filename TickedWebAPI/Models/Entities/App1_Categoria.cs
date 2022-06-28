using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class App1_Categoria
    {
        [Key]
        public int? Id { get; set; }
        public string? Categoria { get; set; }
        public bool? Estado_Cat { get; set; }
    }
}