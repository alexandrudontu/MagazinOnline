using magazinOnline.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class CartDTO
    {
        public long CartId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int Quantity { get; set; }
    }
}
