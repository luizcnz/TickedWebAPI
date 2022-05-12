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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ticked;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App1Asignacion>(entity =>
            {
                entity.ToTable("app1_asignacion");

                entity.HasIndex(e => e.ServiceTagId, "app1_asignacion_serviceTag_id_58336a96");

                entity.HasIndex(e => e.UsuarioId, "app1_asignacion_usuario_id_d6181304");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Observacion).HasColumnName("observacion");

                entity.Property(e => e.ServiceTagId).HasColumnName("serviceTag_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.ServiceTag)
                    .WithMany(p => p.App1Asignacions)
                    .HasForeignKey(d => d.ServiceTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_asignacion_serviceTag_id_58336a96_fk_app1_registroequipo_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.App1Asignacions)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_asignacion_usuario_id_d6181304_fk_app1_user_id");
            });

            modelBuilder.Entity<App1Capacidad>(entity =>
            {
                entity.ToTable("app1_capacidad");

                entity.HasIndex(e => e.EspecificacionId, "app1_capacidad_especificacion_id_9c02d94d");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EspecificacionId).HasColumnName("especificacion_id");

                entity.Property(e => e.Valor)
                    .HasMaxLength(5)
                    .HasColumnName("valor");

                entity.HasOne(d => d.Especificacion)
                    .WithMany(p => p.App1Capacidads)
                    .HasForeignKey(d => d.EspecificacionId)
                    .HasConstraintName("app1_capacidad_especificacion_id_9c02d94d_fk_app1_especificacion_id");
            });

            modelBuilder.Entity<App1Categoriaequipo>(entity =>
            {
                entity.ToTable("app1_categoriaequipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoriaEquipo)
                    .HasMaxLength(50)
                    .HasColumnName("categoriaEquipo");
            });

            modelBuilder.Entity<App1Categoria>(entity =>
            {
                entity.ToTable("app1_categoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(200)
                    .HasColumnName("categoria");

                entity.Property(e => e.EstadoCat).HasColumnName("estado_Cat");
            });

            modelBuilder.Entity<App1Departamento>(entity =>
            {
                entity.ToTable("app1_departamentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .HasColumnName("departamento");
            });

            modelBuilder.Entity<App1Detalleequipo>(entity =>
            {
                entity.ToTable("app1_detalleequipo");

                entity.HasIndex(e => e.CapacidadId, "app1_detalleequipo_capacidad_id_f678007a");

                entity.HasIndex(e => e.ServiceTagId, "app1_detalleequipo_serviceTag_id_c6fcd55e");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CapacidadId).HasColumnName("capacidad_id");

                entity.Property(e => e.ServiceTagId).HasColumnName("serviceTag_id");

                entity.HasOne(d => d.Capacidad)
                    .WithMany(p => p.App1Detalleequipos)
                    .HasForeignKey(d => d.CapacidadId)
                    .HasConstraintName("app1_detalleequipo_capacidad_id_f678007a_fk_app1_capacidad_id");

                entity.HasOne(d => d.ServiceTag)
                    .WithMany(p => p.App1Detalleequipos)
                    .HasForeignKey(d => d.ServiceTagId)
                    .HasConstraintName("app1_detalleequipo_serviceTag_id_c6fcd55e_fk_app1_registroequipo_id");
            });

            modelBuilder.Entity<App1Detalleticked>(entity =>
            {
                entity.ToTable("app1_detalleticked");

                entity.HasIndex(e => e.NumeroId, "app1_detalleticked_numero_id_d2e95c5d");

                entity.HasIndex(e => e.UsuarioId, "app1_detalleticked_usuario_id_daa7190b");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(100)
                    .HasColumnName("adjunto");

                entity.Property(e => e.Comentarios).HasColumnName("comentarios");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.NumeroId).HasColumnName("numero_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Numero)
                    .WithMany(p => p.App1Detalletickeds)
                    .HasForeignKey(d => d.NumeroId)
                    .HasConstraintName("app1_detalleticked_numero_id_d2e95c5d_fk_app1_ticked_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.App1Detalletickeds)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("app1_detalleticked_usuario_id_daa7190b_fk_app1_user_id");
            });

            modelBuilder.Entity<App1Especificacion>(entity =>
            {
                entity.ToTable("app1_especificacion");

                entity.HasIndex(e => e.TipoEId, "app1_especificacion_tipoE_id_95e9faae");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEspecificacion)
                    .HasMaxLength(15)
                    .HasColumnName("nombreEspecificacion");

                entity.Property(e => e.TipoEId).HasColumnName("tipoE_id");

                entity.HasOne(d => d.TipoE)
                    .WithMany(p => p.App1Especificacions)
                    .HasForeignKey(d => d.TipoEId)
                    .HasConstraintName("app1_especificacion_tipoE_id_95e9faae_fk_app1_tipoespecificacion_id");
            });

            modelBuilder.Entity<App1Estado>(entity =>
            {
                entity.ToTable("app1_estado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(300)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<App1Estadoequipo>(entity =>
            {
                entity.ToTable("app1_estadoequipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoE)
                    .HasMaxLength(30)
                    .HasColumnName("estadoE");
            });

            modelBuilder.Entity<App1Historico>(entity =>
            {
                entity.ToTable("app1_historico");

                entity.HasIndex(e => e.ServiceTagId, "app1_historico_serviceTag_id_20e7a805");

                entity.HasIndex(e => e.UsuariosId, "app1_historico_usuarios_id_8bd0cb60");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Historico).HasColumnName("historico");

                entity.Property(e => e.ServiceTagId).HasColumnName("serviceTag_id");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.ServiceTag)
                    .WithMany(p => p.App1Historicos)
                    .HasForeignKey(d => d.ServiceTagId)
                    .HasConstraintName("app1_historico_serviceTag_id_20e7a805_fk_app1_registroequipo_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.App1Historicos)
                    .HasForeignKey(d => d.UsuariosId)
                    .HasConstraintName("app1_historico_usuarios_id_8bd0cb60_fk_app1_user_id");
            });

            modelBuilder.Entity<App1Marca>(entity =>
            {
                entity.ToTable("app1_marca");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .HasColumnName("marca");
            });

            modelBuilder.Entity<App1Modelo>(entity =>
            {
                entity.ToTable("app1_modelo");

                entity.HasIndex(e => e.MarcaId, "app1_modelo_marca_id_fdcf0579");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(30)
                    .HasColumnName("modelo");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.App1Modelos)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_modelo_marca_id_fdcf0579_fk_app1_marca_id");
            });

            modelBuilder.Entity<App1Nivelimpacto>(entity =>
            {
                entity.ToTable("app1_nivelimpacto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(10)
                    .HasColumnName("nivel");
            });

            modelBuilder.Entity<App1Prioridad>(entity =>
            {
                entity.ToTable("app1_prioridad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Prioridad)
                    .HasMaxLength(10)
                    .HasColumnName("prioridad");
            });

            modelBuilder.Entity<App1Registroequipo>(entity =>
            {
                entity.ToTable("app1_registroequipo");

                entity.HasIndex(e => e.CategoriaEquipoId, "app1_registroequipo_categoriaEquipo_id_6b7037b5");

                entity.HasIndex(e => e.EstadoEquipoId, "app1_registroequipo_estadoEquipo_id_edeb5b83");

                entity.HasIndex(e => e.ModeloId, "app1_registroequipo_modelo_id_a2ab3ec7");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Buenacondicion).HasColumnName("buenacondicion");

                entity.Property(e => e.CategoriaEquipoId).HasColumnName("categoriaEquipo_id");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.EstadoEquipoId).HasColumnName("estadoEquipo_id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.ModeloId).HasColumnName("modelo_id");

                entity.Property(e => e.ServiceTag)
                    .HasMaxLength(50)
                    .HasColumnName("serviceTag");

                entity.HasOne(d => d.CategoriaEquipo)
                    .WithMany(p => p.App1Registroequipos)
                    .HasForeignKey(d => d.CategoriaEquipoId)
                    .HasConstraintName("app1_registroequipo_categoriaEquipo_id_6b7037b5_fk_app1_categoriaequipo_id");

                entity.HasOne(d => d.EstadoEquipo)
                    .WithMany(p => p.App1Registroequipos)
                    .HasForeignKey(d => d.EstadoEquipoId)
                    .HasConstraintName("app1_registroequipo_estadoEquipo_id_edeb5b83_fk_app1_estadoequipo_id");

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.App1Registroequipos)
                    .HasForeignKey(d => d.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_registroequipo_modelo_id_a2ab3ec7_fk_app1_modelo_id");
            });

            modelBuilder.Entity<App1Registrotransferencium>(entity =>
            {
                entity.ToTable("app1_registrotransferencia");

                entity.HasIndex(e => e.NumeroId, "app1_registrotransferencia_numero_id_8b3e61f2");

                entity.HasIndex(e => e.RecibeId, "app1_registrotransferencia_recibe_id_415eeec8");

                entity.HasIndex(e => e.TransfiereId, "app1_registrotransferencia_transfiere_id_201250fe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comentario).HasColumnName("comentario");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.NumeroId).HasColumnName("numero_id");

                entity.Property(e => e.RecibeId).HasColumnName("recibe_id");

                entity.Property(e => e.TransfiereId).HasColumnName("transfiere_id");

                entity.HasOne(d => d.Numero)
                    .WithMany(p => p.App1Registrotransferencia)
                    .HasForeignKey(d => d.NumeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_registrotransferencia_numero_id_8b3e61f2_fk_app1_ticked_id");

                entity.HasOne(d => d.Recibe)
                    .WithMany(p => p.App1RegistrotransferenciumRecibes)
                    .HasForeignKey(d => d.RecibeId)
                    .HasConstraintName("app1_registrotransferencia_recibe_id_415eeec8_fk_app1_user_id");

                entity.HasOne(d => d.Transfiere)
                    .WithMany(p => p.App1RegistrotransferenciumTransfieres)
                    .HasForeignKey(d => d.TransfiereId)
                    .HasConstraintName("app1_registrotransferencia_transfiere_id_201250fe_fk_app1_user_id");
            });

            modelBuilder.Entity<App1Subcategoria>(entity =>
            {
                entity.ToTable("app1_subcategoria");

                entity.HasIndex(e => e.CategoriaId, "app1_subcategoria_categoria_id_6e40e9bd");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.EstadoSub).HasColumnName("estado_Sub");

                entity.Property(e => e.Subcategoria)
                    .HasMaxLength(200)
                    .HasColumnName("subcategoria");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.App1Subcategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_subcategoria_categoria_id_6e40e9bd_fk_app1_categoria_id");
            });

            modelBuilder.Entity<App1Ticked>(entity =>
            {
                entity.ToTable("app1_ticked");

                entity.HasIndex(e => e.ApoyoId, "app1_ticked_apoyo_id_e49777a1");

                entity.HasIndex(e => e.EstadoId, "app1_ticked_estado_id_42bd5756");

                entity.HasIndex(e => e.NivelImpactoId, "app1_ticked_nivelImpacto_id_8a82b6ab");

                entity.HasIndex(e => e.PrioridadId, "app1_ticked_prioridad_id_71065ef3");

                entity.HasIndex(e => e.PropietarioId, "app1_ticked_propietario_id_517c3115");

                entity.HasIndex(e => e.SubcategoriaId, "app1_ticked_subcategoria_id_204ba677");

                entity.HasIndex(e => e.TecnicoId, "app1_ticked_tecnico_id_799fd10e");

                entity.HasIndex(e => e.TipoAsistenciaId, "app1_ticked_tipoAsistencia_id_51b2e779");

                entity.HasIndex(e => e.TratamientoId, "app1_ticked_tratamiento_id_e4f2bf3d");

                entity.HasIndex(e => e.UsuarioSolicitanteId, "app1_ticked_usuarioSolicitante_id_163c0e6a");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(100)
                    .HasColumnName("adjunto");

                entity.Property(e => e.ApoyoId).HasColumnName("apoyo_id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.EstadoId).HasColumnName("estado_id");

                entity.Property(e => e.FechaAtendido).HasColumnName("fechaAtendido");

                entity.Property(e => e.FechaCerrado).HasColumnName("fechaCerrado");

                entity.Property(e => e.FechaEspera).HasColumnName("fechaEspera");

                entity.Property(e => e.Fechacreado).HasColumnName("fechacreado");

                entity.Property(e => e.NivelImpactoId).HasColumnName("nivelImpacto_id");

                entity.Property(e => e.Numero)
                    .HasMaxLength(100)
                    .HasColumnName("numero");

                entity.Property(e => e.PrioridadId).HasColumnName("prioridad_id");

                entity.Property(e => e.PropietarioId).HasColumnName("propietario_id");

                entity.Property(e => e.SubcategoriaId).HasColumnName("subcategoria_id");

                entity.Property(e => e.TecnicoId).HasColumnName("tecnico_id");

                entity.Property(e => e.TipoAsistenciaId).HasColumnName("tipoAsistencia_id");

                entity.Property(e => e.TratamientoId).HasColumnName("tratamiento_id");

                entity.Property(e => e.UsuarioSolicitanteId).HasColumnName("usuarioSolicitante_id");

                entity.HasOne(d => d.Apoyo)
                    .WithMany(p => p.App1TickedApoyos)
                    .HasForeignKey(d => d.ApoyoId)
                    .HasConstraintName("app1_ticked_apoyo_id_e49777a1_fk_app1_user_id");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("app1_ticked_estado_id_42bd5756_fk_app1_estado_id");

                entity.HasOne(d => d.NivelImpacto)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.NivelImpactoId)
                    .HasConstraintName("app1_ticked_nivelImpacto_id_8a82b6ab_fk_app1_nivelimpacto_id");

                entity.HasOne(d => d.Prioridad)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.PrioridadId)
                    .HasConstraintName("app1_ticked_prioridad_id_71065ef3_fk_app1_prioridad_id");

                entity.HasOne(d => d.Propietario)
                    .WithMany(p => p.App1TickedPropietarios)
                    .HasForeignKey(d => d.PropietarioId)
                    .HasConstraintName("app1_ticked_propietario_id_517c3115_fk_app1_user_id");

                entity.HasOne(d => d.Subcategoria)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.SubcategoriaId)
                    .HasConstraintName("app1_ticked_subcategoria_id_204ba677_fk_app1_subcategoria_id");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.App1TickedTecnicos)
                    .HasForeignKey(d => d.TecnicoId)
                    .HasConstraintName("app1_ticked_tecnico_id_799fd10e_fk_app1_user_id");

                entity.HasOne(d => d.TipoAsistencia)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.TipoAsistenciaId)
                    .HasConstraintName("app1_ticked_tipoAsistencia_id_51b2e779_fk_app1_tipoasistencia_id");

                entity.HasOne(d => d.Tratamiento)
                    .WithMany(p => p.App1Tickeds)
                    .HasForeignKey(d => d.TratamientoId)
                    .HasConstraintName("app1_ticked_tratamiento_id_e4f2bf3d_fk_app1_tratamiento_id");

                entity.HasOne(d => d.UsuarioSolicitante)
                    .WithMany(p => p.App1TickedUsuarioSolicitantes)
                    .HasForeignKey(d => d.UsuarioSolicitanteId)
                    .HasConstraintName("app1_ticked_usuarioSolicitante_id_163c0e6a_fk_app1_user_id");
            });

            modelBuilder.Entity<App1Tipoasistencium>(entity =>
            {
                entity.ToTable("app1_tipoasistencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Asistencia)
                    .HasMaxLength(10)
                    .HasColumnName("asistencia");
            });

            modelBuilder.Entity<App1Tipoespecificacion>(entity =>
            {
                entity.ToTable("app1_tipoespecificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoE)
                    .HasMaxLength(15)
                    .HasColumnName("tipoE");
            });

            modelBuilder.Entity<App1Tratamiento>(entity =>
            {
                entity.ToTable("app1_tratamiento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tratamiento)
                    .HasMaxLength(50)
                    .HasColumnName("tratamiento");
            });

            modelBuilder.Entity<App1User>(entity =>
            {
                entity.ToTable("app1_user");

                entity.HasIndex(e => e.Username, "UQ__app1_use__F3DBC572CADC8C6D")
                    .IsUnique();

                entity.HasIndex(e => e.DepartamentoId, "app1_user_departamento_id_3677810f");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .HasMaxLength(12)
                    .HasColumnName("celular");

                entity.Property(e => e.DateJoined).HasColumnName("date_joined");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.App1Users)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("app1_user_departamento_id_3677810f_fk_app1_departamentos_id");
            });

            modelBuilder.Entity<App1UserGroup>(entity =>
            {
                entity.ToTable("app1_user_groups");

                entity.HasIndex(e => e.GroupId, "app1_user_groups_group_id_0b2ecce6");

                entity.HasIndex(e => e.UserId, "app1_user_groups_user_id_1cdff3cb");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "app1_user_groups_user_id_group_id_2f8d5583_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.App1UserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_user_groups_group_id_0b2ecce6_fk_auth_group_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.App1UserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_user_groups_user_id_1cdff3cb_fk_app1_user_id");
            });

            modelBuilder.Entity<App1UserUserPermission>(entity =>
            {
                entity.ToTable("app1_user_user_permissions");

                entity.HasIndex(e => e.PermissionId, "app1_user_user_permissions_permission_id_bff830c4");

                entity.HasIndex(e => e.UserId, "app1_user_user_permissions_user_id_6a7e9014");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "app1_user_user_permissions_user_id_permission_id_cc424875_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.App1UserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_user_user_permissions_permission_id_bff830c4_fk_auth_permission_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.App1UserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app1_user_user_permissions_user_id_6a7e9014_fk_app1_user_id");
            });

            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name, "UQ__auth_gro__72E12F1B3B6524A0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthGroupPermission>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codename)
                    .HasMaxLength(100)
                    .HasColumnName("codename");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermissions)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionFlag).HasColumnName("action_flag");

                entity.Property(e => e.ActionTime).HasColumnName("action_time");

                entity.Property(e => e.ChangeMessage).HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .HasMaxLength(200)
                    .HasColumnName("object_repr");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("django_admin_log_user_id_c564eba6_fk_app1_user_id");
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .HasMaxLength(100)
                    .HasColumnName("app_label");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<DjangoMigration>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.App)
                    .HasMaxLength(255)
                    .HasColumnName("app");

                entity.Property(e => e.Applied).HasColumnName("applied");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("PK__django_s__B3BA0F1F1FE950D1");

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(40)
                    .HasColumnName("session_key");

                entity.Property(e => e.ExpireDate).HasColumnName("expire_date");

                entity.Property(e => e.SessionData).HasColumnName("session_data");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
