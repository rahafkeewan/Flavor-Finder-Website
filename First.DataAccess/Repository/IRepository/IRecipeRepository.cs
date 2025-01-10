using RecipesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.DataAccess.Repository.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        void Add(Recipe obj);
        void Remove(Recipe obj);
        void update(Recipe obj);
    }
}
