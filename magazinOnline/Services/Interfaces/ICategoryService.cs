using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAll();
        CategoryDTO GetById(long Id);
        CategoryDTO Create(CategoryDTO categoryDTO);
        public void Delete(long id);
        void Update(long id, CategoryDTO categoryDTO);
    }
}
