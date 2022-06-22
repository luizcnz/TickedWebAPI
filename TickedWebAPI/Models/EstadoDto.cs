using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class EstadoDto
    {
        [Key]
        public int Id { get; set; }
        public string? EstadoTicked { get; set; }
    }
}
