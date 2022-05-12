using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Capacidad
    {
        public App1Capacidad()
        {
            App1Detalleequipos = new HashSet<App1Detalleequipo>();
        }

        public int Id { get; set; }
        public string Valor { get; set; } = null!;
        public int? EspecificacionId { get; set; }

        public virtual App1Especificacion? Especificacion { get; set; }
        public virtual ICollection<App1Detalleequipo> App1Detalleequipos { get; set; }
    }
}
