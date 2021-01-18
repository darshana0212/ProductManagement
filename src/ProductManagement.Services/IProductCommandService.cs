using ProductManagement.Data;

namespace ProductManagement.Service
{
    public interface IProductCommandService
    {
        int SaveProduct(Product product);

        int SaveProductOption(ProductOption productOption);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
