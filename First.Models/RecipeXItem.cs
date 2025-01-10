using RecipesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWebsite.Modelss
{
    public class RecipeXItem
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = default!;
    }
}
