using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using magazinOnline.Services;
using magazinOnline.Services.Interfaces;
using magazinOnline.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace magazinOnline.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CategoryController(ICategoryService CategoryService,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _categoryService = CategoryService;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(_categoryService.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] long Id)
        {
            return Ok(_categoryService.GetById(Id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDTO categoryDTO)
        {
            _categoryService.Create(categoryDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CategoryDTO categoryDTO)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            categoryDTO.CategoryId = id; // Ensure the correct ID is set
            _categoryService.Update(id, categoryDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _categoryService.Delete(id);
            return Ok();
        }

    }
}
