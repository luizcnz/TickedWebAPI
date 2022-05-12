using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Estadoequipo
    {
        public App1Estadoequipo()
        {
            App1Registroequipos = new HashSet<App1Registroequipo>();
        }

        public int Id { get; set; }
        public string EstadoE { get; set; } = null!;

        public virtual ICollection<App1Registroequipo> App1Registroequipos { get; set; }
    }
}
