using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class RecipeIngredientRepository : GenericRepository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(DbContextRecipe context)
           : base(context) { }
    }
}
