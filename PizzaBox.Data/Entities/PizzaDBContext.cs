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

        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaComponent> PizzaComponent { get; set; }
        public virtual DbSet<User> User { get; set; }

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

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK_CID");

                entity.ToTable("Component", "Pizza");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Cost).HasColumnType("numeric(3, 2)");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK_InvId");

                entity.ToTable("InventoryItem", "Pizza");

                entity.Property(e => e.Cid).HasColumnName("CId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocId)
                    .HasName("PK_LocID");

                entity.ToTable("Location", "Pizza");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "Pizza");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.LocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderID");
            });

            modelBuilder.Entity<PizzaComponent>(entity =>
            {
                entity.HasKey(e => e.Pcid)
                    .HasName("PK_PCID");

                entity.ToTable("PizzaComponent", "Pizza");

                entity.Property(e => e.Pcid).HasColumnName("PCId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Pizza");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
