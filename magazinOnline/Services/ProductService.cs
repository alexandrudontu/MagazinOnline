using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories;
using magazinOnline.Repositories.Interfaces;
using magazinOnline.Services.Interfaces;

namespace magazinOnline.Services
{
    public class ProductService: IProductService
    {
        private List<Product> Products;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetAll()
        {
            return _productRepository.GetAll().Select(x => new ProductDTO()
            {
                Name = x.Name,
                Description = x.Description,
                Quantity = x.Quantity,
                Price = x.Price,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public ProductDTO GetById(long Id)
        {
            var product = _productRepository.GetById(Id);
            if (product != null)
            {
                return new ProductDTO()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
            }
            return null; // Handle null case
        }

        public ProductDTO Create(ProductDTO productDTO)
        {
            var product = new Product()
            {
                Name = productDTO.Name,
                Description= productDTO.Description,
                Quantity = productDTO.Quantity,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };
            _productRepository.Create(product);

            // Return the created product DTO
            return new ProductDTO()
            {
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }

        public void Update(long id, ProductDTO productDTO)
        {
            // Convert ProductDTO to Product entity
            var product = new Product()
            {
                ProductId = id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Quantity = productDTO.Quantity,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };
            _productRepository.Update(id, product);
        }

        public void Delete(long id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                _productRepository.Delete(product.ProductId);
            }
        }
    }
}
