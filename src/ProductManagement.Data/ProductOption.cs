using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductManagement.Data
{
    public class ProductOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Code { get;  set; }

        public string Description { get;  set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Product Product { get;  set; }

        public int ProductId { get;  set; }

    }
}
