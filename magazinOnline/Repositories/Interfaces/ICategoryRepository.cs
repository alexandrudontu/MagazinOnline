using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(long Id);
        void Create(Category category);
        void Update(long id, Category category);
        void Delete(long id);
    }
}
