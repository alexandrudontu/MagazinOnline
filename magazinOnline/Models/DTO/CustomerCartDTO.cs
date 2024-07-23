using magazinOnline.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class CustomerCartDTO
    {
        public long CustomerCartId { get; set; }
        public long CustomerId { get; set; }
        public long CartId { get; set; }
        public CartDTO CartDTO { get; set; }
        public List<CartProductDTO> CartProductDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }

    }
}
