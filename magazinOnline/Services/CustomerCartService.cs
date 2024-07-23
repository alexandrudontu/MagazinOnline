using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories.Interfaces;
using magazinOnline.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace magazinOnline.Services
{
    public class CustomerCartService : ICustomerCartService
    {
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly DatabaseContext _dbContext;

        public CustomerCartService(ICustomerCartRepository customerCartRepository, IProductRepository productRepository, DatabaseContext dbContext)
        {
            _customerCartRepository = customerCartRepository;
            _productRepository = productRepository;
            _dbContext = dbContext;
        }

        public CustomerCartDTO GetByCustomerId(long customerId)
        {
            var customerCart = _customerCartRepository.GetByCustomerId(customerId);

            if (customerCart == null)
            {
                return null; // or handle accordingly
            }

            // Retrieve products in the cart
            var cartProducts = _dbContext.CartProducts
                .Where(cp => cp.CartId == customerCart.CustomerCartId)
                .Select(cp => cp.Product)
                .ToList();

            // Map products to DTO
            var productsInCart = cartProducts.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId
            }).ToList();

            // Map cart entity to DTO and include products
            return new CustomerCartDTO
            {
                CartId = customerCart.CustomerCartId,
                //CartProductDTO = productsInCart
            };
        }

        public void AddProductToCart(long customerId, long productId, int quantity)
        {
            var customerCart = _customerCartRepository.GetByCustomerId(customerId);

            if (customerCart == null)
            {
                customerCart = new CustomerCart { 
                    CustomerId = customerId
                };
                //_customerCartRepository.Create(customerCart);
            }

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Add product to cart directly in the database
            _dbContext.CartProducts.Add(new CartProduct { CartId = customerCart.CustomerCartId, ProductId = productId });
            _dbContext.SaveChanges();
        }

        public void RemoveProductFromCart(long customerId, long productId)
        {
            var customerCart = _customerCartRepository.GetByCustomerId(customerId);

            if (customerCart == null)
            {
                throw new InvalidOperationException("Cart not found.");
            }

            // Find the cart product and remove it directly in the database
            var cartProduct = _dbContext.CartProducts.FirstOrDefault(cp => cp.CartId == customerCart.CustomerCartId && cp.ProductId == productId);
            if (cartProduct != null)
            {
                _dbContext.CartProducts.Remove(cartProduct);
                _dbContext.SaveChanges();
            }
        }

        public void Checkout(long customerId)
        {
            var customerCart = _customerCartRepository.GetByCustomerId(customerId);

            if (customerCart == null)
            {
                throw new InvalidOperationException("Cart not found.");
            }

            // Perform checkout process (e.g., create order, update product quantities, etc.)

            // After checkout, you may want to clear the cart
            var cartProducts = _dbContext.CartProducts.Where(cp => cp.CartId == customerCart.CustomerCartId).ToList();
            _dbContext.CartProducts.RemoveRange(cartProducts);
            _dbContext.SaveChanges();
        }
    }
}
