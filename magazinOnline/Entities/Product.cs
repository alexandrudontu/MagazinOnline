using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
    }
}
