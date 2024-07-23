using magazinOnline.Entities;
using magazinOnline.Models.DTO;

namespace magazinOnline.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetAll();
        ProductDTO GetById(long Id);
        ProductDTO Create(ProductDTO productDTO);
        public void Delete(long id);
        void Update(long id, ProductDTO productDTO);
    }
}
