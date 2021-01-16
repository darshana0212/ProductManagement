using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }
    }
}
