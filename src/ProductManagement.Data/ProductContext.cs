using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasIndex(p => p.Code)
                .IsUnique();

            builder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Entity<ProductOption>()
                .HasIndex(p => p.Code)
                .IsUnique();
        }
    }
}

