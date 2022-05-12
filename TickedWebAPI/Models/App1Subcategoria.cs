using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Subcategoria
    {
        public App1Subcategoria()
        {
            App1Tickeds = new HashSet<App1Ticked>();
        }

        public int Id { get; set; }
        public string Subcategoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        public bool? EstadoSub { get; set; }

        public virtual App1Categoria Categoria { get; set; } = null!;
        public virtual ICollection<App1Ticked> App1Tickeds { get; set; }
    }
}
