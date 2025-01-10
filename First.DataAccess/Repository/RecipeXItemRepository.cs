using RecipesWeb.DataAccess.Data;
using RecipesWeb.DataAccess.Repository.IRepository;
using RecipesWebsite.Modelss;

namespace RecipesWeb.DataAccess.Repository
{
    public class RecipeXItemRepository : Repository<RecipeXItem>, IRecipeXItemRepository
    {

        private readonly ApplicationDbContext _db;
        public RecipeXItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(RecipeXItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
