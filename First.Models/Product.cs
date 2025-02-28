﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RecipesWebsite.Modelss;

namespace RecipesWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]

        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public ICollection<RecipeXItem> RecipeXItem { get; set; } = new List<RecipeXItem>();


    }
}
