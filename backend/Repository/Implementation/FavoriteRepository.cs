using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(DbContextRecipe context)
           : base(context) { }

        public async Task<Favorite> GetByUserAndRecipe(int userId, int recipeId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f =>
                    f.UserId == userId &&
                    f.RecipeId == recipeId &&
                    f.IsActive == true
                );
        }

        public async Task<IEnumerable<Favorite>> GetByUserId(int userId)
        {
            return await _context.Favorites
                .Include(f => f.Recipe)
                    .ThenInclude(r => r.Ratings)
                .Where(f =>
                    f.UserId == userId &&
                    f.IsActive == true &&
                    f.Recipe != null &&
                    f.Recipe.IsActive == true
                )
                .ToListAsync();
        }

    }
}
