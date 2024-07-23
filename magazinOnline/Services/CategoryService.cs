using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories;
using magazinOnline.Repositories.Interfaces;
using magazinOnline.Services.Interfaces;

namespace magazinOnline.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> Categories;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDTO> GetAll()
        {
            return _categoryRepository.GetAll().Select(x => new CategoryDTO()
            {
                Title = x.Title,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }

        public CategoryDTO GetById(long Id)
        {
            var category = _categoryRepository.GetById(Id);
            if (category != null)
            {
                return new CategoryDTO()
                {
                    Title = category.Title,
                    DisplayOrder = category.DisplayOrder
                };
            }
            return null; // Handle null case
        }

        public CategoryDTO Create(CategoryDTO categoryDTO)
        {
            var category = new Category()
            {
                Title = categoryDTO.Title,
                DisplayOrder = categoryDTO.DisplayOrder
            };
            _categoryRepository.Create(category);

            // Return the created category DTO
            return new CategoryDTO()
            {
                Title = category.Title,
                DisplayOrder = category.DisplayOrder
            };
        }

        public void Update(long id, CategoryDTO categoryDTO)
        {
            // Convert CategoryDTO to Category entity
            var category = new Category()
            {
                CategoryId = id,
                Title = categoryDTO.Title,
                DisplayOrder = categoryDTO.DisplayOrder
            };
            _categoryRepository.Update(id, category);
        }

        public void Delete(long id)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                _categoryRepository.Delete(category.CategoryId);
            }
        }
    }
}
