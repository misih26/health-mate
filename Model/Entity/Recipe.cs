using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Recipe
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
