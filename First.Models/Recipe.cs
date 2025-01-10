using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesWebsite.Modelss;

namespace RecipesWeb.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; } // primary key of the table
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Discription { get; set; }
        public ICollection<RecipeXItem> RecipeXItem { get; set; } = new List<RecipeXItem>();



    }
}
