using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class DetalleTickedDto
    {
        
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public string? Usuario { get; set; }
        public string? Adjunto { get; set; }

    }
}
