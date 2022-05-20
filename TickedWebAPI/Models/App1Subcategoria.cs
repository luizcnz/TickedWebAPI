using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Subcategoria
    {
        public int Id { get; set; }
        public string Subcategoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        public bool? EstadoSub { get; set; }

    }

    public partial class App1SubcategoriaJoin
    {
        public int Id { get; set; }
        public string Subcategoria { get; set; } = null!;
        public string Categoria { get; set; }
        public bool? EstadoSub { get; set; }

    }
}
