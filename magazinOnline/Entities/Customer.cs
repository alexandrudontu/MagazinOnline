using magazinOnline.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazinOnline.Entities
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String PhoneNo { get; set; }
        public CustomerCart customerCart { get; set; }
        public List<CustomerOrder> CustomerOrder { get; set; }
    }
}
