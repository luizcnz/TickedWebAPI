using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class TickedContext : DbContext
    {
        
        public TickedContext(DbContextOptions<TickedContext> options)
            : base(options)
        {
        }


        public DbSet<CategoriaDto> Categorias { get; set; }
        public DbSet<CategoriaSubcat> CategoriasySubcat { get; set; }
        public DbSet<DetalleTickedDto> DetalleTickeds { get; set; }
        public DbSet<EstadoDto> Estados { get; set; }
        public DbSet<PrioridadDto> Prioridades { get; set; }
        public DbSet<SubcategoriaJoin> Subcategorias { get; set; }
        public DbSet<TickedDto> Tickeds { get; set; }
        public DbSet<TickedId> TickedsId { get; set; }
    }
}