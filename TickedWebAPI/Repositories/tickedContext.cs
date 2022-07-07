using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class TickedContext : DbContext
    {        
        public TickedContext(DbContextOptions<TickedContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaModel> Categorias { get; set; } = null!;
        public DbSet<CategoriaConSubcategoriasModel> CategoriasConSubcategorias { get; set; } = null!;
        public DbSet<DetalleTickedModel> DetalleTickeds { get; set; } = null!;
        public DbSet<EstadoModel> Estados { get; set; } = null!;
        public DbSet<PrioridadModel> Prioridades { get; set; } = null!;
        public DbSet<SubcategoriaModel> Subcategorias { get; set; } = null!;
        public DbSet<SubcategoriaConInnerJoinModel> SubcategoriasConInnerJoin { get; set; } = null!;
        public DbSet<TickedModel> Tickeds { get; set; } = null!;
        public DbSet<UsuarioModel> Usuarios { get; set; } = null!;
    }
}