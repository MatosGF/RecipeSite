using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class RecipeCategoryRepository : GenericRepository<RecipeCategory>, IRecipeCategoryRepository
    {
        public RecipeCategoryRepository(DbContextRecipe context)
           : base(context) { }
    }
}
