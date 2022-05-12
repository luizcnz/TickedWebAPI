using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Categoria
    {
        public App1Categoria()
        {
            App1Subcategoria = new HashSet<App1Subcategoria>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public bool? EstadoCat { get; set; }

        public virtual ICollection<App1Subcategoria> App1Subcategoria { get; set; }
    }
}
