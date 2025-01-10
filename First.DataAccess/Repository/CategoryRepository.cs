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
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {

        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Add(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Recipe obj)
        {
            throw new NotImplementedException();
        }

        public void update(Category obj)
        {
            _db.Categories.Update(obj);
        }

        public void update(Product obj)
        {
            throw new NotImplementedException();
        }

        public void update(Recipe obj)
        {
            throw new NotImplementedException();
        }
    }
}
