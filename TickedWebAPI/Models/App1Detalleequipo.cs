using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Detalleequipo
    {
        public int Id { get; set; }
        public int? CapacidadId { get; set; }
        public int? ServiceTagId { get; set; }

        public virtual App1Capacidad? Capacidad { get; set; }
        public virtual App1Registroequipo? ServiceTag { get; set; }
    }
}
