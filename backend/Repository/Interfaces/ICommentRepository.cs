using Models.Entities;

namespace Repository.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByRecipeIdAsync(int recipeId);

    }
}
