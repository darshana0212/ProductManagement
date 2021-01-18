using System;
using System.Collections.Generic;
using System.Text;
using ProductManagement.Data;

namespace ProductManagement.Service
{
    public interface IProductCommandService
    {
        int SaveProduct(Product product);

        int SaveProductOption(ProductOption productOption);
    }
}
