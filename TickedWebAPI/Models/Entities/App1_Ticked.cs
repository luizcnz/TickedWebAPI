using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models.Entities
{
    public class App1_Ticked
    {
        [Key]
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public string? Fechacreado { get; set; }
        public string? Fechaatendido { get; set; }
        public int? Estado { get; set; }
        public int? Prioridad { get; set; }
        public int? Subcategoria { get; set; }
        public int? UsuarioSolicitante { get; set; }
    }
}