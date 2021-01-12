using System;
using System.Collections.Generic;
using System.Text;
using ProductManagement.Data;

namespace ProductManagement.Service
{
    public interface IProductCommandService
    {
        Product GetProduct();
    }
}
