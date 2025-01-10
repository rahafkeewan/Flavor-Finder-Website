using RecipesWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipesWebsite.Modelss;

namespace RecipesWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplictionUser> ApplictionUser { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeXItem> RecipeXItem { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplyOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplyOrder = 2},
                new Category { Id = 3, Name = "History", DisplyOrder = 3 }
                );
           modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 1,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 2,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 2,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.",
                    CategoryId = 3,
                    ImageUrl = ""

                }




                );


            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Leaves and Wonders",
                    Discription="jdbfjvef"
                },

                new Recipe
                {
                    Id = 2,
                    Name = "Wonders",
                    Discription = "gg"
                }
                );


            modelBuilder.Entity<RecipeXItem>().HasKey(e => new { e.RecipeId, e.ProductId });
        }
    }
}
