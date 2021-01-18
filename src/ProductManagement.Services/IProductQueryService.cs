using ProductManagement.Data;
using System.Collections.Generic;

namespace ProductManagement.Service
{
    public interface IProductQueryService
    {
        Product GetProduct(int id);

        List<Product> GetProducts();
    }
}
