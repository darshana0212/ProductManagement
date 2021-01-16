namespace ProductManagement.Data.Repository
{
    public interface IProductRepository 
    {
        int AddProduct(Product product);

        Product GetProduct(int id);
    }
}
