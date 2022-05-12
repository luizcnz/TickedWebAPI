using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1UserGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual AuthGroup Group { get; set; } = null!;
        public virtual App1User User { get; set; } = null!;
    }
}
