using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=localhost;Initial Catalog=ProductManagement;User Id=sa;Password=sa;");
    }
}

