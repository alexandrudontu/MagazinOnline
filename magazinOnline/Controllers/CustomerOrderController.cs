using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using magazinOnline.Services;
using magazinOnline.Services.Interfaces;
using magazinOnline.Models.DTO;


namespace magazinOnline.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CustomerOrderController(ICustomerOrderService CustomerOrderService,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _customerOrderService = CustomerOrderService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet("{customerId}")]
        public IActionResult GetOrdersByCustomerId(long customerId)
        {
            List<CustomerOrderDTO> customerOrders = _customerOrderService.GetOrdersByCustomerId(customerId);
            if (customerOrders != null)
            {
                return Ok(customerOrders);
            }
            return NotFound();
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(long orderId)
        {
            CustomerOrderDTO customerOrder = _customerOrderService.GetOrderById(orderId);
            if (customerOrder != null)
            {
                return Ok(customerOrder);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] CustomerOrderDTO customerOrderDTO)
        {
            if (customerOrderDTO == null)
            {
                return BadRequest("Invalid customer order data");
            }

            try
            {
                _customerOrderService.PlaceOrder(customerOrderDTO);
                return StatusCode(201); // Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
