using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickedWebAPI.Models
{
    public class TickedDto
    {
        [Key]
        public int? id { get; set; }
        public string? numero { get; set; }
        public string? descripcion { get; set; }
        public string? adjunto { get; set; }
        public DateTime? fechacreado { get; set; }
        public DateTime? fechaAtendido { get; set; }
        public string? estado { get; set; }
        public string? prioridad { get; set; }
        public string? subcategoria { get; set; }
        public string? solicitante { get; set; }
        [NotMapped]
        public virtual object? detalles { get; set; } 
    }

    public class TickedPost
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

    public class TickedId
    {
        public int id {get;set;}
    }
}

