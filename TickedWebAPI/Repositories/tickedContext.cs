using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;

namespace TickedWebAPI.Repositories
{
    public partial class tickedContext : DbContext
    {
        public tickedContext(DbContextOptions<tickedContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaDto> App1Categoria { get; set; } = null!;
        public DbSet<SubcategoriaDto> App1Subcategoria { get; set; } = null!;
        public DbSet<TickedDto> App1Tickeds { get; set; } = null!;
        public DbSet<EstadoDto> App1Estado { get; set; } = null!;
    }
}
