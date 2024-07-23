using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(long Id);
        void Create(Product product);
        void Update(long id, Product product);
        void Delete(long id);
    }
}
