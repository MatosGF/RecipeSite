using Models.Entities;

namespace Repository.Interfaces
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        Task<Favorite> GetByUserAndRecipe(int userId, int recipeId);
        Task<IEnumerable<Favorite>> GetByUserId(int userId);
    }
}
