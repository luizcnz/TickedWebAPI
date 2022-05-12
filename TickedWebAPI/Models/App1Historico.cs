using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Historico
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Historico { get; set; }
        public int? ServiceTagId { get; set; }
        public int? UsuariosId { get; set; }

        public virtual App1Registroequipo? ServiceTag { get; set; }
        public virtual App1User? Usuarios { get; set; }
    }
}
