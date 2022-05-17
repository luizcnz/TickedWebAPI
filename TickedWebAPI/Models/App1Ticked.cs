using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [DisplayName("Estado")]
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

        
        [ForeignKey("EstadoId")]
        public virtual App1Estado? Estado { get; set; }
        public virtual App1Nivelimpacto? NivelImpacto { get; set; }

        [ForeignKey("PrioridadId")]
        public virtual App1Prioridad? Prioridad { get; set; }
        public virtual App1User? Propietario { get; set; }

        [ForeignKey("SubcategoriaId")]
        public virtual App1Subcategoria? Subcategoria { get; set; }

        [ForeignKey("TecnicoId")]
        public virtual App1User? Tecnico { get; set; }

        [ForeignKey("TipoAsistenciaId")]
        public virtual App1Tipoasistencium? TipoAsistencia { get; set; }

        [ForeignKey("TratamientoId")]
        public virtual App1Tratamiento? Tratamiento { get; set; }

        [ForeignKey("UsuarioSolicitanteId")]
        public virtual App1User? UsuarioSolicitante { get; set; }

        public virtual ICollection<App1Detalleticked> App1Detalletickeds { get; set; }
        public virtual ICollection<App1Registrotransferencium> App1Registrotransferencia { get; set; }
    }

    public partial class TickedGET
    {

        //public TickedDto()
        //{
        //    App1Detalletickeds = new HashSet<App1Detalleticked>();
        //    App1Registrotransferencia = new HashSet<App1Registrotransferencium>();
        //}
        public int? Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }
        public DateTime? FechaAtendido { get; set; }
        public DateTime? FechaCerrado { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? Subcategoria { get; set; }
        public string? Tecnico { get; set; }
        public string? TipoAsistencia { get; set; }
        public string? Tratamiento { get; set; }
        public string? UsuarioSolicitante { get; set; }

        //public virtual ICollection<App1Detalleticked> App1Detalletickeds { get; set; }
        //public virtual ICollection<App1Registrotransferencium> App1Registrotransferencia { get; set; }


    }
}
