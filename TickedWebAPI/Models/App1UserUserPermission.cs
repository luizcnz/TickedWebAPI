using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1UserUserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual AuthPermission Permission { get; set; } = null!;
        public virtual App1User User { get; set; } = null!;
    }
}
