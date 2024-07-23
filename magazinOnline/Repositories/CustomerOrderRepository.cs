using magazinOnline.Entities;
using magazinOnline.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace magazinOnline.Repositories
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly DatabaseContext _context;

        public CustomerOrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<CustomerOrder> GetOrdersByCustomerId(long customerId)
        {
            return _context.CustomerOrders
                .Where(co => co.CustomerId == customerId)
                .ToList();
        }

        public CustomerOrder GetOrderById(long orderId)
        {
            return _context.CustomerOrders.FirstOrDefault(co => co.CustomerOrderId == orderId);
        }

        public void PlaceOrder(CustomerOrder customerOrder)
        {
            _context.CustomerOrders.Add(customerOrder);
            _context.SaveChanges();
        }
    }
}
