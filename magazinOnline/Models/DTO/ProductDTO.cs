using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long CategoryId { get; set; }
    }
}
