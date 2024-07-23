using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories.Interfaces;
using System;
using System.Linq;

namespace magazinOnline.Repositories
{
    public class CustomerCartRepository : ICustomerCartRepository
    {
        private readonly DatabaseContext _context;

        public CustomerCartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public CustomerCart GetByCustomerId(long customerId)
        {
            var customerCart = _context.CustomerCarts.FirstOrDefault(c => c.CustomerId == customerId);
            if (customerCart == null)
            {
                return null; // Customer's cart not found
            }

            var cart = new CustomerCart
            {
                CustomerId = customerCart.CustomerId,
                CartProduct = customerCart.CartProduct.Select(cp => new CartProduct
                {
                    CartProductId = cp.CartProductId,
                    ProductId = cp.ProductId,
                    Name = cp.Product.Name,
                    Quantity = cp.Quantity
                }).ToList()
            };

            return cart;
        }

        public void AddProductToCart(long customerId, long productId, int quantity)
        {
            var customerCart = _context.CustomerCarts.FirstOrDefault(c => c.CustomerId == customerId);
            if (customerCart == null)
            {
                customerCart = new CustomerCart { CustomerId = customerId };
                _context.CustomerCarts.Add(customerCart);
            }

            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            customerCart.CartProduct.Add(new CartProduct
            {
                ProductId = productId,
                Quantity = quantity
            });

            _context.SaveChanges();
        }

        public void RemoveProductFromCart(long customerId, long cartProductId)
        {
            var customerCart = _context.CustomerCarts.FirstOrDefault(c => c.CustomerId == customerId);
            if (customerCart == null)
            {
                return; // Customer's cart not found
            }

            var cartProduct = customerCart.CartProduct.FirstOrDefault(cp => cp.CartProductId == cartProductId);
            if (cartProduct != null)
            {
                _context.CartProducts.Remove(cartProduct);
                _context.SaveChanges();
            }
        }

        public void CheckoutCart(long customerId)
        {
            
        }
    }
}
