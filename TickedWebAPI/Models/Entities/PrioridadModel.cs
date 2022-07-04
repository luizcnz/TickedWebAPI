using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class PrioridadModel
    {
        [Key]
        public int id { get; set; }
        public string? prioridad { get; set; }
    }
}
