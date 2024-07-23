using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories.Interfaces;

namespace magazinOnline.Repositories;

public class ProductRepository : IProductRepository
{
    public List<Product> GetAll()
    {
        using (var db = new ApplicationDbContext())
        {
            return db.Products.ToList();
        }
    }

    public Product GetById(long Id)
    {
        using (var db = new ApplicationDbContext())
        {
            return db.Products.FirstOrDefault(x => x.ProductId == Id);

        }

    }
    public void Create(Product product)
    {
        using (var db = new ApplicationDbContext())
        {
            var myProduct = new Product
            {
                Name = product.Name,
                Description= product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                 
            };

            db.Products.Add(myProduct);
            db.SaveChanges();
        }
    }

    public void Update(long id, Product product)
    {
        using (var db = new ApplicationDbContext())
        {
            var myProduct = db.Products.FirstOrDefault(c => c.ProductId == id);
            if (myProduct != null)
            {
                // Update product properties with values from ProductDTO
                myProduct.Name = product.Name;
                myProduct.Description = product.Description;
                myProduct.Price = product.Price;
                myProduct.Quantity = product.Quantity;
                myProduct.CategoryId = product.CategoryId;

                db.SaveChanges();
            }
        }
    }
    public void Delete(long id)
    {
        using (var db = new ApplicationDbContext())
        {
            var myProduct = db.Products.FirstOrDefault(c => c.ProductId == id);
            if (myProduct != null)
            {
                db.Products.Remove(myProduct);
                db.SaveChanges();
            }
        }
    }
}
