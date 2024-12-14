using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappers
{
    public class RecipeMapper
    {
        public RecipeDTO Map(Recipe recipe)
        {
            RecipeDTO recipeDTO = new RecipeDTO();
            recipeDTO.Name = recipe.Name;
            recipeDTO.Description = recipe.Description;
            recipeDTO.Id = recipe.Id;
            return recipeDTO;
        }

        public List<RecipeDTO> Map(List<Recipe> recipes)
        {
            List<RecipeDTO> recipeDTOs = new List<RecipeDTO>();
            foreach (Recipe recipe in  recipes)
            {
                recipeDTOs.Add(Map(recipe));
            }

            return recipeDTOs;
        }
    }
}
