using magazinOnline.Entities;
using magazinOnline.Models.DTO;
using magazinOnline.Repositories.Interfaces;

namespace magazinOnline.Repositories;

public class CategoryRepository: ICategoryRepository
{
    public List<Category> GetAll()
    {
        using (var db = new DatabaseContext())
        {
            return db.Categories.ToList();
        }
    }

    public Category GetById(long Id)
    {
        using (var db = new DatabaseContext())
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == Id);

        }

    }
    public void Create(Category category)
    {
        using (var db = new DatabaseContext())
        {
            var myCategory = new Category
            {
                Title = category.Title,
                DisplayOrder = category.DisplayOrder
            };

            db.Categories.Add(myCategory);
            db.SaveChanges();
        }
    }

    public void Update(long id, Category category)
    {
        using (var db = new DatabaseContext())
        {
            var myCategory = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (myCategory != null)
            {
                // Update category properties with values from CategoryDTO
                myCategory.Title = category.Title;
                myCategory.DisplayOrder = category.DisplayOrder;

                db.SaveChanges();
            }
        }
    }
    public void Delete(long id)
    {
        using (var db = new DatabaseContext())
        {
            var myCategory = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (myCategory != null)
            {
                db.Categories.Remove(myCategory);
                db.SaveChanges();
            }
        }
    }
}
