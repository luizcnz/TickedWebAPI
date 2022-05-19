using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TickedWebAPI.Models
{
    public partial class tickedContext : DbContext
    {
        public tickedContext()
        {
        }

        public tickedContext(DbContextOptions<tickedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<App1Asignacion> App1Asignacions { get; set; } = null!;
        public virtual DbSet<App1Capacidad> App1Capacidads { get; set; } = null!;
        public virtual DbSet<App1Categoriaequipo> App1Categoriaequipos { get; set; } = null!;
        public virtual DbSet<App1Categoria> App1Categoria { get; set; } = null!;
        public virtual DbSet<App1Departamento> App1Departamentos { get; set; } = null!;
        public virtual DbSet<App1Detalleequipo> App1Detalleequipos { get; set; } = null!;
        public virtual DbSet<App1Detalleticked> App1Detalletickeds { get; set; } = null!;
        public virtual DbSet<App1Especificacion> App1Especificacions { get; set; } = null!;
        public virtual DbSet<App1Estado> App1Estados { get; set; } = null!;
        public virtual DbSet<App1Estadoequipo> App1Estadoequipos { get; set; } = null!;
        public virtual DbSet<App1Historico> App1Historicos { get; set; } = null!;
        public virtual DbSet<App1Marca> App1Marcas { get; set; } = null!;
        public virtual DbSet<App1Modelo> App1Modelos { get; set; } = null!;
        public virtual DbSet<App1Nivelimpacto> App1Nivelimpactos { get; set; } = null!;
        public virtual DbSet<App1Prioridad> App1Prioridads { get; set; } = null!;
        public virtual DbSet<App1Registroequipo> App1Registroequipos { get; set; } = null!;
        public virtual DbSet<App1Registrotransferencium> App1Registrotransferencia { get; set; } = null!;
        public virtual DbSet<App1Subcategoria> App1Subcategoria { get; set; } = null!;
        public virtual DbSet<App1Ticked> App1Tickeds { get; set; } = null!;
        //public virtual List<App1TickedPost> App1TickedsPost { get; set; } = null!;
        public virtual DbSet<App1Tipoasistencium> App1Tipoasistencia { get; set; } = null!;
        public virtual DbSet<App1Tipoespecificacion> App1Tipoespecificacions { get; set; } = null!;
        public virtual DbSet<App1Tratamiento> App1Tratamientos { get; set; } = null!;
        public virtual DbSet<App1User> App1Users { get; set; } = null!;
        public virtual DbSet<App1UserGroup> App1UserGroups { get; set; } = null!;
        public virtual DbSet<App1UserUserPermission> App1UserUserPermissions { get; set; } = null!;
        public virtual DbSet<AuthGroup> AuthGroups { get; set; } = null!;
        public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; } = null!;
        public virtual DbSet<AuthPermission> AuthPermissions { get; set; } = null!;
        public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; } = null!;
        public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; } = null!;
        public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; } = null!;
        public virtual DbSet<DjangoSession> DjangoSessions { get; set; } = null!;

    }
}
