using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductManagement.Data
{
    public class EfMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=ProductManagement;User Id=sa;Password=sa;";

            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ProductContext(optionsBuilder.Options);
        }       
    }
}