using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class App1_DetalleTicked
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comentarios { get; set; }
        public string? Adjunto { get; set; }
        public int? Numero_Id { get; set; }
        public int? Usuario_Id { get; set; }

    }
}