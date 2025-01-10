using RecipesWeb.DataAccess.Data;
using RecipesWeb.DataAccess.Repository.IRepository;
using RecipesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.DataAccess.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {

        private readonly ApplicationDbContext _db;
        public RecipeRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Add(Recipe obj)
        {
            _db.Recipe.Add(obj);

        }

        public void Remove(Recipe obj)
        {
            _db.Recipe.Remove(obj);
        }

        public void update(Recipe obj)
        {
            _db.Recipe.Update(obj);
        }

        
    }
}
