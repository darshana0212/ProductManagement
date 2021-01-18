using Microsoft.EntityFrameworkCore;
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

        public void Delete(Product existingProduct)
        {
            _productContext.Products.Remove(existingProduct);
            SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _productContext.Products
                .Include(x => x.ProductOptions)
                .ToList();
        }

        public List<ProductOption> GetProductOptionsByProductId(int productId)
        {
            return _productContext.ProductOptions.Where(x => x.ProductId == productId).ToList();
        }

        public ProductOption GetProductOptionById(int productOptionId)
        {
            return _productContext.ProductOptions.FirstOrDefault(x => x.Id == productOptionId);
        }

        public void DeleteProductOption(ProductOption existingProductOption)
        {
            _productContext.ProductOptions.Remove(existingProductOption);
            SaveChanges();
        }

        public void DeleteProductOptions(List<ProductOption> existingProductOptions)
        {
            _productContext.ProductOptions.RemoveRange(existingProductOptions);
            SaveChanges();
        }
    }
}
