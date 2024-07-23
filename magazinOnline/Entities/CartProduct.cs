using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class CartProduct
    {
        [Key]
        public long CartProductId { get; set; }
        [Required]
        [ForeignKey("Cart")]
        public long CartId { get; set; }
        public String Name { get; set; }
        public Cart Cart { get; set; }     
        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
