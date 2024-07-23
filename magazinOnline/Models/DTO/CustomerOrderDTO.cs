using magazinOnline.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class CustomerOrderDTO
    {
        public long CustomerOrderId { get; set; }
        public long CustomerCartId { get; set; }
        public long CustomerId { get; set; }
        public CustomerCartDTO CustomerCartDTO { get; set; }
        public long OrderId { get; set; }
        public OrderDTO OrderDTO { get; set; }

    }
}
