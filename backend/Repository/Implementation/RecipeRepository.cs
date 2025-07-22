using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;


namespace Repository.Implementation
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContextRecipe context)
           : base(context) { }

        //public async Task ApproveRecipe(int recipeId)
        //{
        //    var recipe = await _context.Set<Recipe>().FindAsync(recipeId);
        //    if (recipe != null)
        //    {
        //        recipe.Status = "Approved";
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<IEnumerable<Recipe>> GetPendingRecipes()
        {
            return await _context.Set<Recipe>()
                                .Where(r => r.Status == "Pending")
                                .ToListAsync();
        }
    }
}
