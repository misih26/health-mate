using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappers
{
    public class CategoryMapper
    {

        private RecipeMapper recipeMapper;
        public CategoryMapper(RecipeMapper recipeMapper) {
            this.recipeMapper = recipeMapper;
        }

        public CategoryDTO Map(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = category.Name;
            categoryDTO.Id = category.Id;
            categoryDTO.Recipes = recipeMapper.Map(category.Recipes);

            return categoryDTO;
        }

        public List<CategoryDTO> Map(List<Category> categories)
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                categoryDTOs.Add(Map(category));
            }
            return categoryDTOs;
        }
    }
}
