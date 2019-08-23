using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Entities
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
        {
        }

        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pizza> Pizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:lnc-sql.database.windows.net,1433;Initial Catalog=PizzaDB;Persist Security Info=False;User ID=sqladmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Price).HasColumnType("numeric(12, 2)");
            });
        }
    }
}
