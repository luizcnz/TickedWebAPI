using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class DetalleTickedDto
    {
        [Key]
        public int id {get;set;} 
        public DateTime fecha { get; set; }
        public string? comentario { get; set; }
        public string? usuario { get; set; }
        public string? adjunto { get; set; }
    }
}
