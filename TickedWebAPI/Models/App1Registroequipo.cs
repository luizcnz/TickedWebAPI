using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Registroequipo
    {
        public App1Registroequipo()
        {
            App1Asignacions = new HashSet<App1Asignacion>();
            App1Detalleequipos = new HashSet<App1Detalleequipo>();
            App1Historicos = new HashSet<App1Historico>();
        }

        public int Id { get; set; }
        public string ServiceTag { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public bool? Disponible { get; set; }
        public bool? Buenacondicion { get; set; }
        public int? CategoriaEquipoId { get; set; }
        public int? EstadoEquipoId { get; set; }
        public int ModeloId { get; set; }

        public virtual App1Categoriaequipo? CategoriaEquipo { get; set; }
        public virtual App1Estadoequipo? EstadoEquipo { get; set; }
        public virtual App1Modelo Modelo { get; set; } = null!;
        public virtual ICollection<App1Asignacion> App1Asignacions { get; set; }
        public virtual ICollection<App1Detalleequipo> App1Detalleequipos { get; set; }
        public virtual ICollection<App1Historico> App1Historicos { get; set; }
    }
}
