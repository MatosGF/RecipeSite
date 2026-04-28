using Models;

namespace Service.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> AddAsync(RatingDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RatingDto>> GetAll();
        Task<RatingDto> GetById(int entityId);
        Task<RatingDto> Update(RatingDto entityDto);
        Task<double> GetAverageByRecipe(int recipeId);
        Task<RatingDto> AddOrUpdate(RatingDto dto);
        Task<RatingDto?> GetUserRating(int userId, int recipeId);

    }
}
