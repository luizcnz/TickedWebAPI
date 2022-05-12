using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Marca
    {
        public App1Marca()
        {
            App1Modelos = new HashSet<App1Modelo>();
        }

        public int Id { get; set; }
        public string Marca { get; set; } = null!;

        public virtual ICollection<App1Modelo> App1Modelos { get; set; }
    }
}
