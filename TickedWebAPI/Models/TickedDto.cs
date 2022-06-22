using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public class TickedDto
    {
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public string? Fechacreado { get; set; }
        public string? Fechaatendido { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? Subcategoria { get; set; }
        public string? UsuarioSolicitante { get; set; }
        public virtual ICollection<DetalleTickedDto>? Detalles { get; set; }
    }

    public class App1TickedPost
    {

        [Required(ErrorMessage = "Se debe dar una descripcion para el Ticked")]
        public string? Descripcion { get; set; }

        public string? Adjunto { get; set; }

        [Required(ErrorMessage = "Se debe proporcionar una fecha")]
        public DateTime? Fechacreado { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un nivel de prioridad")]
        public int? PrioridadId { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la subcategoria del Ticked")]
        public int? SubcategoriaId { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el codigo del usuario solicitante")]
        public int? UsuarioSolicitanteId { get; set; }
    }
}
