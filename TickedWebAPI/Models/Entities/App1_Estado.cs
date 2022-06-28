using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class App1_Estado
    {
        [Key]
        public int Id { get; set; }
        public string? Estado { get; set; }
    }
}
