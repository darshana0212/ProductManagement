using System;

namespace ProductManagement.Data
{
    public class Product

    {

        public Product(string code, decimal price, string description)
        {
            Code = code;
            Price = price;
            Description = description;
        }

        public string Code { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }



    }
}
