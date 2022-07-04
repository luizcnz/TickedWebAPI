using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class EstadoDto
    {
        [Key]
        public int id { get; set; }
        public string? estado { get; set; }
    }
}
