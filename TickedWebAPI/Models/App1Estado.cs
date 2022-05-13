using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TickedWebAPI.Models
{
    public partial class App1Estado
    {
        public App1Estado()
        {
            App1Tickeds = new HashSet<App1Ticked>();
        }

        
        public int Id { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<App1Ticked> App1Tickeds { get; set; }
    }
}
