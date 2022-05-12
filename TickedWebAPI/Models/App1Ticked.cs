using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Ticked
    {
        public App1Ticked()
        {
            App1Detalletickeds = new HashSet<App1Detalleticked>();
            App1Registrotransferencia = new HashSet<App1Registrotransferencium>();
        }

        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }
        public DateTime? FechaAtendido { get; set; }
        public DateTime? FechaEspera { get; set; }
        public DateTime? FechaCerrado { get; set; }
        public int? ApoyoId { get; set; }
        public int? EstadoId { get; set; }
        public int? NivelImpactoId { get; set; }
        public int? PrioridadId { get; set; }
        public int? PropietarioId { get; set; }
        public int? SubcategoriaId { get; set; }
        public int? TecnicoId { get; set; }
        public int? TipoAsistenciaId { get; set; }
        public int? TratamientoId { get; set; }
        public int? UsuarioSolicitanteId { get; set; }

        public virtual App1User? Apoyo { get; set; }
        public virtual App1Estado? Estado { get; set; }
        public virtual App1Nivelimpacto? NivelImpacto { get; set; }
        public virtual App1Prioridad? Prioridad { get; set; }
        public virtual App1User? Propietario { get; set; }
        public virtual App1Subcategoria? Subcategoria { get; set; }
        public virtual App1User? Tecnico { get; set; }
        public virtual App1Tipoasistencium? TipoAsistencia { get; set; }
        public virtual App1Tratamiento? Tratamiento { get; set; }
        public virtual App1User? UsuarioSolicitante { get; set; }
        public virtual ICollection<App1Detalleticked> App1Detalletickeds { get; set; }
        public virtual ICollection<App1Registrotransferencium> App1Registrotransferencia { get; set; }
    }
}
