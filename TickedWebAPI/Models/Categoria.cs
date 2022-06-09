using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class Categoria
    {
        public int Id { get; set; }
        public string? CategoriaTicked { get; set; } = null!;
        public bool? EstadoCat { get; set; }
    }


    public partial class CategoriaSubcat
    {
        public int Id { get; set; }
        public string? CategoriaTicked { get; set; } = null!;
        public bool? EstadoCat { get; set; }
        public ICollection<Subcategoria>? Subcategoria { get; set; }
    }
}
