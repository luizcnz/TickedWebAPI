using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Detalleticked
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Comentarios { get; set; } = null!;
        public string? Adjunto { get; set; }
        public int? NumeroId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual App1Ticked? Numero { get; set; }
        public virtual App1User? Usuario { get; set; }
    }
}
