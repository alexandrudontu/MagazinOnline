using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories.Interfaces;
using magazinOnline.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace magazinOnline.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;

        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        public List<CustomerOrderDTO> GetOrdersByCustomerId(long customerId)
        {
            List<CustomerOrder> customerOrders = _customerOrderRepository.GetOrdersByCustomerId(customerId);
            return customerOrders.Select(co => new CustomerOrderDTO
            {
                CustomerOrderId = co.CustomerOrderId,
                CustomerCartId = co.CustomerCartId,
                OrderId = co.OrderId
            }).ToList();
        }

        public CustomerOrderDTO GetOrderById(long orderId)
        {
            CustomerOrder customerOrder = _customerOrderRepository.GetOrderById(orderId);
            if (customerOrder != null)
            {
                return new CustomerOrderDTO
                {
                    CustomerOrderId = customerOrder.CustomerOrderId,
                    CustomerCartId = customerOrder.CustomerCartId,
                    OrderId = customerOrder.OrderId
                };
            }
            return null;
        }

        public void PlaceOrder(CustomerOrderDTO customerOrderDTO)
        {
            CustomerOrder customerOrder = new CustomerOrder
            {
                CustomerCartId = customerOrderDTO.CustomerCartId,
                OrderId = customerOrderDTO.OrderId
            };
            _customerOrderRepository.PlaceOrder(customerOrder);
        }
    }
}
