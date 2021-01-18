using System.Collections.Generic;

namespace ProductManagement.Data.Repository
{
    public interface IProductRepository 
    {
        int AddProduct(Product product);

        Product GetProduct(int id);

        int AddProductOption(ProductOption productOption);

        int SaveChanges();

        void Delete(Product existingProduct);

        List<Product> GetAllProducts();
    }
}
