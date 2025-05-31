using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entity;

namespace health_mate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController
    {
        private CategoryLogic categoryLogic;
        public CategoryController(CategoryLogic categoryLogic)
        {
                this.categoryLogic = categoryLogic;
        }

        [HttpGet(Name = "GetAllCategories")]
        public List<CategoryDTO> Get()
        {
            return categoryLogic.GetAllCategories();
        }

        [HttpGet("{id}")]
        public CategoryDTO Get(string id)
        {
            return categoryLogic.GetById(id);
        }

        [HttpGet("ByName/{name}")]
        public CategoryDTO GetName(string name)
        {
            return categoryLogic.GetByName(name);
        }

        [HttpPost]
        public SuccessDTO Add([FromBody] CategoryCreationDTO categoryCreationDto)
        {
            return categoryLogic.Add(categoryCreationDto);
        }

        [HttpPut]
       // [Authorize(Roles = "admin")]
        public SuccessDTO Update([FromBody] CategoryModificationDTO categoryModificationDto)
        {
            return categoryLogic.Modify(categoryModificationDto);
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "admin")]
        public SuccessDTO Delete(string id)
        {
            return categoryLogic.Remove(id);
        }
    }
}
