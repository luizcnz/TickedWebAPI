using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class EstadoModel
    {
        [Key]
        public int id { get; set; }
        public string? estado { get; set; }
    }
}
