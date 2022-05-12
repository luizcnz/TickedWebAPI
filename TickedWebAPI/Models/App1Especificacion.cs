using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Especificacion
    {
        public App1Especificacion()
        {
            App1Capacidads = new HashSet<App1Capacidad>();
        }

        public int Id { get; set; }
        public string NombreEspecificacion { get; set; } = null!;
        public int? TipoEId { get; set; }

        public virtual App1Tipoespecificacion? TipoE { get; set; }
        public virtual ICollection<App1Capacidad> App1Capacidads { get; set; }
    }
}
