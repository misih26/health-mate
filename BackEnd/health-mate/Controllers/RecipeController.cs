using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entity;

namespace health_mate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController
    {
        private RecipeLogic RecipeLogic;
        public RecipeController(RecipeLogic recipeLogic)
        {
                RecipeLogic = recipeLogic;
        }

        [HttpGet(Name = "GetAllRecipies")]
        public List<RecipeDTO> Get()
        {
            return RecipeLogic.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public RecipeDTO Get(string id)
        {
            return RecipeLogic.GetById(id);
        }

        [HttpPost]
        public SuccessDTO Add([FromBody] RecipeCreationDTO recipeDto)
        {
            return RecipeLogic.Add(recipeDto);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public SuccessDTO Update([FromBody] RecipeModificationDTO recipeModificationDTO)
        {
            return RecipeLogic.Modify(recipeModificationDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public SuccessDTO Delete(string id)
        {
            return RecipeLogic.Remove(id);
        }
    }
}
