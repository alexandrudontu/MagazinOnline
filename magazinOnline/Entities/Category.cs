using System.ComponentModel.DataAnnotations;

namespace magazinOnline.Entities
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
    }
}
