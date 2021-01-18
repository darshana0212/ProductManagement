using System;
using System.Collections.Generic;
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
            return _productContext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
           return _productContext.Products.Find(id);
           
        }

        public int AddProductOption(ProductOption productOption)
        {
            _productContext.Add(productOption);
            return _productContext.SaveChanges();
        }
    }
}
