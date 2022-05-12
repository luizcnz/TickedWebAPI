using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Registrotransferencium
    {
        public int Id { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroId { get; set; }
        public int? RecibeId { get; set; }
        public int? TransfiereId { get; set; }

        public virtual App1Ticked Numero { get; set; } = null!;
        public virtual App1User? Recibe { get; set; }
        public virtual App1User? Transfiere { get; set; }
    }
}
