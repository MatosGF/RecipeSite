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

        public async Task ApproveRecipe(int recipeId)
        {
            var recipe = await _context.Set<Recipe>().FindAsync(recipeId);
            if (recipe != null)
            {
                recipe.Status = "Approved";
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Recipe>> GetApprovedRecipes()
        {
            return await _context.Recipes
                .Include(r => r.User)
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.MeasurementType)
                .Include(r => r.Ratings)   
                .Where(r => r.Status == "Approved")
                .ToListAsync();
        }


        public async Task<IEnumerable<Recipe>> GetPendingRecipes()
        {
            return await _context.Set<Recipe>()
                .Include(r => r.User)
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.MeasurementType)
                .Where(r => r.Status == "Pending")
                .ToListAsync();
        }


        public async Task<Recipe> GetByIdWithIngredientsAsync(int id)
        {
            return await _context.Set<Recipe>()
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.MeasurementType)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recipe>> SearchRecipes(string? search)
        {
            var query = _context.Recipes
                .Include(r => r.User)
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.Ratings)
                .Where(r => r.Status == "Approved")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(r =>
                    r.Title.ToLower().Contains(search) ||
                    r.Category.Name.ToLower().Contains(search) ||
                    r.Difficulty.Name.ToLower().Contains(search) ||
                    r.RecipeIngredients.Any(ri =>
                        ri.Ingredient.Name.ToLower().Contains(search)
                    )
                );
            }

            return await query.ToListAsync();
        }

    }
}
