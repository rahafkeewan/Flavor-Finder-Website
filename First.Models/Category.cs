using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipesWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // primary key of the table
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplyOrder { get; set; }
    }
}
