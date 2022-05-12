using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Tratamiento
    {
        public App1Tratamiento()
        {
            App1Tickeds = new HashSet<App1Ticked>();
        }

        public int Id { get; set; }
        public string Tratamiento { get; set; } = null!;

        public virtual ICollection<App1Ticked> App1Tickeds { get; set; }
    }
}
