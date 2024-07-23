using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Repositories.Interfaces
{
    public interface ICustomerOrderRepository
    {
        public List<CustomerOrder> GetOrdersByCustomerId(long customerId);
        public CustomerOrder GetOrderById(long orderId);
        public void PlaceOrder(CustomerOrder customerOrder);
    }
}
