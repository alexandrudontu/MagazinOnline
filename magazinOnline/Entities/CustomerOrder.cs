using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class CustomerOrder
    {
        [Key]
        public long CustomerOrderId { get; set; }
        [ForeignKey("CustomerCart")]
        public long CustomerCartId { get; set; }
        public CustomerCart CustomerCart { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }
    }
}
