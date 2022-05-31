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

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Subcategoria> App1Subcategoria { get; set; } = null!;
        public virtual DbSet<Ticked> App1Tickeds { get; set; } = null!;
    }
}
