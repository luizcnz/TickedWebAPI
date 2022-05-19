using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Categoria
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public bool? EstadoCat { get; set; }
    }
}
