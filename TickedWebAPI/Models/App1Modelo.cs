using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Modelo
    {
        public App1Modelo()
        {
            App1Registroequipos = new HashSet<App1Registroequipo>();
        }

        public int Id { get; set; }
        public string Modelo { get; set; } = null!;
        public int MarcaId { get; set; }

        public virtual App1Marca Marca { get; set; } = null!;
        public virtual ICollection<App1Registroequipo> App1Registroequipos { get; set; }
    }
}
