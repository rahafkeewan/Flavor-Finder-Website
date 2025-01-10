using RecipesWeb.DataAccess.Data;
using RecipesWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IRecipeRepository Recipe { get; private set; }
        public IRecipeXItemRepository RecipeXItem { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Recipe = new RecipeRepository(_db);
            RecipeXItem = new RecipeXItemRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
