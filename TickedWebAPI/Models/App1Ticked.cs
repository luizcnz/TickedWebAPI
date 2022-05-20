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

        public virtual App1Subcategoria? Subcategoria { get; set; }
    }

    public partial class TickedGET
    {
        public int? Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }
        public DateTime? FechaAtendido { get; set; }
        public int? Estado { get; set; }
        public int? Prioridad { get; set; }
        public int? Subcategoria { get; set; }
        public int? Tecnico { get; set; }
        public int? TipoAsistencia { get; set; }
        public int? Tratamiento { get; set; }
        public int? UsuarioSolicitante { get; set; }
    }

    public partial class TickedGETJoin
    {
        public int? Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }
        public DateTime? FechaAtendido { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? Subcategoria { get; set; }
        public string? Tecnico { get; set; }
        public string? TipoAsistencia { get; set; }
        public string? Tratamiento { get; set; }
        public string? UsuarioSolicitante { get; set; }
    }

    public partial class App1TickedPost
    {
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }

        public int? EstadoId { get; set; }

        public int? PrioridadId { get; set; }

        public int? SubcategoriaId { get; set; }
        public int? TecnicoId { get; set; }
        public int? TipoAsistenciaId { get; set; }
        public int? TratamientoId { get; set; }
        public int? UsuarioSolicitanteId { get; set; }
    }
}
