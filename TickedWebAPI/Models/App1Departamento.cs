using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1Departamento
    {
        public App1Departamento()
        {
            App1Users = new HashSet<App1User>();
        }

        public int Id { get; set; }
        public string Departamento { get; set; } = null!;

        public virtual ICollection<App1User> App1Users { get; set; }
    }
}
