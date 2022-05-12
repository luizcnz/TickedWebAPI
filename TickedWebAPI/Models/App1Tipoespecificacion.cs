using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Tipoespecificacion
    {
        public App1Tipoespecificacion()
        {
            App1Especificacions = new HashSet<App1Especificacion>();
        }

        public int Id { get; set; }
        public string TipoE { get; set; } = null!;

        public virtual ICollection<App1Especificacion> App1Especificacions { get; set; }
    }
}
