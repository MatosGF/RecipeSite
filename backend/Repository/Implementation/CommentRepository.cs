using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DbContextRecipe _context;

        public CommentRepository(DbContextRecipe context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetByRecipeIdAsync(int recipeId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c => c.RecipeId == recipeId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}

