using Logic.Mappers;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.DTO;
using Model.Entity;
using Model.Repository;

namespace Logic
{
    public class CategoryLogic
    {
        private CategoryRepository Repository;
        private CategoryMapper categoryMapper;

        public CategoryLogic(CategoryRepository repository, CategoryMapper categoryMapper)
        {
            this.Repository = repository;
            this.categoryMapper = categoryMapper;
        }
        public List<CategoryDTO> GetAllCategories()
        {
            return categoryMapper.Map(Repository.GetAllCategories());
        }

        public CategoryDTO GetById(string id)
        {
            return categoryMapper.Map(Repository.GetCategoryById(id));
        }

        public CategoryDTO GetByName(string name)
        {
            return categoryMapper.Map(Repository.GetCategoryByName(name));
        }

        public SuccessDTO Remove(string id)
        {
            Repository.DeleteCategory(id);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO Modify(CategoryModificationDTO categoryDto)
        {
            Category category = Repository.GetCategoryById(categoryDto.Id);
            category.Name = categoryDto.Name;

            Repository.ModifyCategory(category);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO Add(CategoryCreationDTO categoryDto)
        {
            Category category = new Category()
            {
                Name = categoryDto.Name
            };

            Repository.SaveCategory(category);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

    }
}
