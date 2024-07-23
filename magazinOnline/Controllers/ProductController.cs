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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProductController(IProductService ProductService,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _productService = ProductService;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(_productService.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] long Id)
        {
            return Ok(_productService.GetById(Id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO productDTO)
        {
            _productService.Create(productDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ProductDTO productDTO)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            productDTO.ProductId = id; // Ensure the correct ID is set
            _productService.Update(id, productDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.Delete(id);
            return Ok();
        }
    }
}
