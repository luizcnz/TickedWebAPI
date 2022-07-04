using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickedWebAPI.Models.Entities
{
    public class TickedModel
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

    public class CrearTickedModel
    {
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime Fechacreado { get; set; }
        public int PrioridadId { get; set; }
        public int SubcategoriaId { get; set; }
        public int UsuarioSolicitanteId { get; set; }
    }
}