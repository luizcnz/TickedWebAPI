using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class PrioridadDto
    {
        [Key]
        public int id { get; set; }
        public string? prioridad { get; set; }
    }
}
