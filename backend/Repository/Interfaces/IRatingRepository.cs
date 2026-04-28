using Models.Entities;

namespace Repository.Interfaces
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<Rating?> GetByUserAndRecipe(int userId, int recipeId);

    }
}
