using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Data
{
    public class Product
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required(ErrorMessage ="Please enter valid code.")]
        public string Code { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<ProductOption> ProductOptions { get; set; }
    }
}
