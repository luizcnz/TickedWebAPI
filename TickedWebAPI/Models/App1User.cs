using System;
using System.Collections.Generic;

namespace TickedWebAPI.Models
{
    public partial class App1User
    {
        public App1User()
        {
            App1Asignacions = new HashSet<App1Asignacion>();
            App1Detalletickeds = new HashSet<App1Detalleticked>();
            App1Historicos = new HashSet<App1Historico>();
            App1RegistrotransferenciumRecibes = new HashSet<App1Registrotransferencium>();
            App1RegistrotransferenciumTransfieres = new HashSet<App1Registrotransferencium>();
            App1TickedApoyos = new HashSet<App1Ticked>();
            App1TickedPropietarios = new HashSet<App1Ticked>();
            App1TickedTecnicos = new HashSet<App1Ticked>();
            App1TickedUsuarioSolicitantes = new HashSet<App1Ticked>();
            App1UserGroups = new HashSet<App1UserGroup>();
            App1UserUserPermissions = new HashSet<App1UserUserPermission>();
            DjangoAdminLogs = new HashSet<DjangoAdminLog>();
        }

        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? LastLogin { get; set; }
        public bool IsSuperuser { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsStaff { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public int? DepartamentoId { get; set; }
        public string? Celular { get; set; }

        public virtual App1Departamento? Departamento { get; set; }
        public virtual ICollection<App1Asignacion> App1Asignacions { get; set; }
        public virtual ICollection<App1Detalleticked> App1Detalletickeds { get; set; }
        public virtual ICollection<App1Historico> App1Historicos { get; set; }
        public virtual ICollection<App1Registrotransferencium> App1RegistrotransferenciumRecibes { get; set; }
        public virtual ICollection<App1Registrotransferencium> App1RegistrotransferenciumTransfieres { get; set; }
        public virtual ICollection<App1Ticked> App1TickedApoyos { get; set; }
        public virtual ICollection<App1Ticked> App1TickedPropietarios { get; set; }
        public virtual ICollection<App1Ticked> App1TickedTecnicos { get; set; }
        public virtual ICollection<App1Ticked> App1TickedUsuarioSolicitantes { get; set; }
        public virtual ICollection<App1UserGroup> App1UserGroups { get; set; }
        public virtual ICollection<App1UserUserPermission> App1UserUserPermissions { get; set; }
        public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; }
    }
}
