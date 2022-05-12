using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class AuthPermission
    {
        public AuthPermission()
        {
            App1UserUserPermissions = new HashSet<App1UserUserPermission>();
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ContentTypeId { get; set; }
        public string Codename { get; set; } = null!;

        public virtual DjangoContentType ContentType { get; set; } = null!;
        public virtual ICollection<App1UserUserPermission> App1UserUserPermissions { get; set; }
        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
    }
}
