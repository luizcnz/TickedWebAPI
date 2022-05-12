using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Asignacion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Observacion { get; set; }
        public int ServiceTagId { get; set; }
        public int UsuarioId { get; set; }

        public virtual App1Registroequipo ServiceTag { get; set; } = null!;
        public virtual App1User Usuario { get; set; } = null!;
    }
}
