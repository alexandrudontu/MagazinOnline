using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using magazinOnline.Services;
using magazinOnline.Services.Interfaces;
using magazinOnline.Models.DTO;
using magazinOnline.Entities;

namespace magazinOnline.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerCartController : ControllerBase
    {
        private readonly ICustomerCartService _customerCartService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CustomerCartController(ICustomerCartService CustomerCartService,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _customerCartService = CustomerCartService;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [HttpGet("{customerId}")]
        public IActionResult GetByCustomerId(long customerId)
        {
            var cart = _customerCartService.GetByCustomerId(customerId);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }
            return Ok(cart);
        }

        [HttpPost("{customerId}/add")]
        public IActionResult AddProductToCart(long customerId, [FromBody] long productId, int quantity)
        {
            try
            {
                _customerCartService.AddProductToCart(customerId, productId, quantity);
                return Ok("Product added to cart successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{customerId}/remove")]
        public IActionResult RemoveProductFromCart(long customerId, [FromBody] long productId)
        {
            try
            {
                _customerCartService.RemoveProductFromCart(customerId, productId);
                return Ok("Product removed from cart successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{customerId}/checkout")]
        public IActionResult Checkout(long customerId)
        {
            try
            {
                _customerCartService.Checkout(customerId);
                return Ok("Checkout successful.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
