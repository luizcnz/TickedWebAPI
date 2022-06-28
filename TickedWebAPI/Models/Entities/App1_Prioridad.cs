using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class App1_Prioridad
    {
        [Key]
        public int Id { get; set; }
        public string? Prioridad { get; set; }
    }
}
