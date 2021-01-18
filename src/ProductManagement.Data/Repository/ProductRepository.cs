using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public int AddProduct(Product product)
        {
            _productContext.Add(product);
            return SaveChanges();
        }

        public Product GetProduct(int id)
        {
           return _productContext.Products.FirstOrDefault(x => x.Id == id);  
        }

        public int AddProductOption(ProductOption productOption)
        {
            _productContext.Add(productOption);
            return _productContext.SaveChanges();
        }

        public int SaveChanges()
        {
            return _productContext.SaveChanges();
        }
    }
}
