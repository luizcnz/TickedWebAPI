using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class PrioridadDto
    {
        [Key]
        public int Id { get; set; }
        public string? PrioridadTicked { get; set; }
    }
}
