using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Models.ViewModols
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public List<int> SelectedItems { get; set; } = default!;
        public IEnumerable<SelectListItem> ItemsList { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}