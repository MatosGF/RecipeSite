using Models;


namespace Service.Interfaces
{
    public interface IFavoriteService
    {
        Task<FavoriteDto> AddAsync(FavoriteDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<FavoriteDto>> GetAll();
        Task<FavoriteDto> GetById(int entityId);
        Task<FavoriteDto> Update(FavoriteDto entityDto);
        Task<bool> Toggle(int userId, int recipeId);
        Task<bool> IsFavorite(int userId, int recipeId);
        Task<IEnumerable<FavoriteRecipeDto>> GetMyFavorites(int userId);
    }
}
