using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class CategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<RecipeDTO> Recipes { get; set; }

    }
}
