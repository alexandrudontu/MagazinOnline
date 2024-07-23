using magazinOnline.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class CartProductDTO
    {
        public long CartProductId { get; set; }
        public long CartId { get; set; }
        public String Name { get; set; }
        public CartDTO CartDTO { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDTO ProductDTO { get; set; }
    }
}
