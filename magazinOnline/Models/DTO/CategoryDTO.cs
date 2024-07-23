using magazinOnline.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Models.DTO
{
    public class CategoryDTO
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
    }
}
