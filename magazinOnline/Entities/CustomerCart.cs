using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class CustomerCart
    {
        [Key]
        public long CustomerCartId { get; set; }
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }   
        public long CartProductId { get; set; }
        public List<CartProduct> CartProduct { get; set; }
        public Customer Customer { get; set; }
    }
}
