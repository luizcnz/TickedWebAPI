using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Tipoasistencium
    {
        public App1Tipoasistencium()
        {
            App1Tickeds = new HashSet<App1Ticked>();
        }

        public int Id { get; set; }
        public string Asistencia { get; set; } = null!;

        public virtual ICollection<App1Ticked> App1Tickeds { get; set; }
    }
}
