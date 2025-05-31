using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Model.Repository
{
    public class CategoryRepository
    {
        HealthMateDbContext HealthMateDbContext { get; }

        public CategoryRepository(HealthMateDbContext healthMateDbContext)
        {
            HealthMateDbContext = healthMateDbContext;
        }

        public List<Category> GetAllCategories()
        {
            return HealthMateDbContext.Category.ToList();
        }

        public bool SaveCategory(Category category)
        {
            HealthMateDbContext.Category.Add(category);
            HealthMateDbContext.SaveChanges();

            return true;
        }

        public bool DeleteCategory(string id)
        {
            Category category = HealthMateDbContext.Category.Where(c => c.Id == id).FirstOrDefault();
            HealthMateDbContext.Category.Remove(category);
            HealthMateDbContext.SaveChanges();


            return true;
        }

        public bool ModifyCategory(Category category)
        {
            HealthMateDbContext.SaveChanges();

            return true;

        }

        public Category GetCategoryById(string id)
        {
            return HealthMateDbContext.Category.FirstOrDefault(c => c.Id == id);
        }

        public Category GetCategoryByName(string name)
        {
            return HealthMateDbContext.Category.FirstOrDefault(c => c.Name == name);
        }
    }
}
