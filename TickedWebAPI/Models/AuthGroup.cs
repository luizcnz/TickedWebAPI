using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class AuthGroup
    {
        public AuthGroup()
        {
            App1UserGroups = new HashSet<App1UserGroup>();
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<App1UserGroup> App1UserGroups { get; set; }
        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
    }
}
