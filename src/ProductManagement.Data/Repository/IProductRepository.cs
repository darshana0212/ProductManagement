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

        List<ProductOption> GetProductOptionsByProductId(int productId);

        ProductOption GetProductOptionById(int productOptionId);

        void DeleteProductOption(ProductOption productOption);

        void DeleteProductOptions(List<ProductOption> existingProductOptions);
    }
}
