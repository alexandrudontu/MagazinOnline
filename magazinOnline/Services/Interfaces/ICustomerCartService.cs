using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Services.Interfaces
{
    public interface ICustomerCartService
    {
        public CustomerCartDTO GetByCustomerId(long customerId);
        public void AddProductToCart(long customerId, long productId, int quantity);
        public void RemoveProductFromCart(long customerId, long productId);
        public void Checkout(long customerId);
    }
}
