using MS.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MS.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1434;initial Catalog=MSOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordering>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
               .Property(p => p.ProductPrice)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
               .Property(p => p.ProductTotalPrice)
               .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
