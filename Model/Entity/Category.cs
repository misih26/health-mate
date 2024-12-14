using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Category
    {
        [Key]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
       public virtual List<Recipe> Recipes { get; set; }



    }
}
