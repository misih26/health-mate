using Logic.Mappers;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.DTO;
using Model.Entity;
using Model.Repository;

namespace Logic
{
    public class RecipeLogic
    {
        private RecipeRepository Repository;
        private RecipeMapper mapper;
        public RecipeLogic(RecipeRepository repository, RecipeMapper mapper)
        {
            this.Repository = repository;
            this.mapper = mapper;
        }
        public List<RecipeDTO> GetAllRecipes()
        {
            return mapper.Map(Repository.GetAllRecipes());
        }

        public RecipeDTO GetById(string id)
        {
            return mapper.Map(Repository.GetRecipeById(id));
        }

        public SuccessDTO Remove(string id)
        {
            Repository.DeleteRecipe(id);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO Modify(RecipeModificationDTO recipeDto)
        {
            Recipe recipe = Repository.GetRecipeById(recipeDto.Id);
            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.CategoryId = recipeDto.CategoryId;

            Repository.ModifyRecipe(recipe);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO Add(RecipeCreationDTO recipeDTO)
        {
            Recipe recipe = new Recipe()
            {
                Name = recipeDTO.Name,
                Description = recipeDTO.Description,
                CategoryId = recipeDTO.CategoryId,
            };

            Repository.SaveRecipe(recipe);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

    }
}
