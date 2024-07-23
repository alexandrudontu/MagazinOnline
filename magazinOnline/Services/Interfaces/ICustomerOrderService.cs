using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        public List<CustomerOrderDTO> GetOrdersByCustomerId(long customerId);
        public CustomerOrderDTO GetOrderById(long orderId);
        public void PlaceOrder(CustomerOrderDTO customerOrderDTO);
    }
}
