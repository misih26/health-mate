using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Model.Repository
{
    public class RecipeRepository
    {
        HealthMateDbContext HealthMateDbContext { get; }

        public RecipeRepository(HealthMateDbContext healthMateDbContext)
        {
            HealthMateDbContext = healthMateDbContext;
        }

        public List<Recipe> GetAllRecipes()
        {
            return HealthMateDbContext.Recipes.ToList();
        }

        public bool SaveRecipe(Recipe recipe)
        {
            HealthMateDbContext.Recipes.Add(recipe);
            HealthMateDbContext.SaveChanges();

            return true;
        }

        public bool DeleteRecipe(string recipeId)
        {
            Recipe recipe = HealthMateDbContext.Recipes.Where(r => r.Id == recipeId).FirstOrDefault();
            HealthMateDbContext.Recipes.Remove(recipe);
            HealthMateDbContext.SaveChanges();


            return true;
        }

        public bool ModifyRecipe(Recipe recipe)
        {
            HealthMateDbContext.SaveChanges();

            return true;

        }

        public Recipe GetRecipeById(string id)
        {
            return HealthMateDbContext.Recipes.FirstOrDefault(r => r.Id == id);
        }
    }
}
