using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class Cart
    {
        [Key]
        public long CartId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int Quantity { get; set; }
    }
}
