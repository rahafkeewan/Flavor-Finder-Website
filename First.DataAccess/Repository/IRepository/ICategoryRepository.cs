using RecipesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Add(Category obj);
        void Remove(Category obj);
        void Remove(Recipe obj);
        void update(Category obj);
        void update(Recipe obj);
    }
}
