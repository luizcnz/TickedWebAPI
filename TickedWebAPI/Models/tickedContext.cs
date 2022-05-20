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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ticked;Trusted_Connection=True;");
            }
        }


        public virtual DbSet<App1Categoria> App1Categoria { get; set; } = null!;
        public virtual DbSet<App1Subcategoria> App1Subcategoria { get; set; } = null!;
        public virtual DbSet<App1Ticked> App1Tickeds { get; set; } = null!;
        //public virtual List<App1TickedPost> App1TickedsPost { get; set; } = null!;
    }
}
