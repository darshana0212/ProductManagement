using ProductManagement.Data;

namespace ProductManagement.Service
{
    public interface IProductCommandService
    {
        int SaveProduct(Product product);

        int SaveProductOption(ProductOption productOption);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProductOption(ProductOption productOption);

        void DeleteProductOption(int optionId);

        void DeleteProductOptionsByProductId(int productId);
    }
}
