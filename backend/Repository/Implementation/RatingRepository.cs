using Models.Entities;
using Repository.Context;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Repository.Implementation
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContextRecipe context)
           : base(context) { }

        public async Task<Rating?> GetByUserAndRecipe(int userId, int recipeId)
        {
            return await _context.Ratings
                .FirstOrDefaultAsync(r => r.UserId == userId && r.RecipeId == recipeId);
        }

    }
}
