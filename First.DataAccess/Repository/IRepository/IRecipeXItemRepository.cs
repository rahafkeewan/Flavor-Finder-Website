using RecipesWeb.Models;
using RecipesWebsite.Modelss;

namespace RecipesWeb.DataAccess.Repository.IRepository
{
    public interface IRecipeXItemRepository : IRepository<RecipeXItem>
    {
        void Add(RecipeXItem obj);
        void Remove(RecipeXItem obj);
        void update(RecipeXItem obj);
    }
}
