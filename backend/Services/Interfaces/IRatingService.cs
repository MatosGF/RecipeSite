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
    }
}
