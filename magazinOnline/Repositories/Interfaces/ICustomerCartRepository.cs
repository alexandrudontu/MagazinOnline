using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Repositories.Interfaces
{
    public interface ICustomerCartRepository
    {
        public CustomerCart GetByCustomerId(long customerId);
        public void AddProductToCart(long customerId, long productId, int quantity);
        public void RemoveProductFromCart(long customerId, long productId);
        public void CheckoutCart(long customerId);
    }
}
