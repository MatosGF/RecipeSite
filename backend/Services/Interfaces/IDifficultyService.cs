using Models;

namespace Service.Interfaces
{
    public interface IDifficultyService
    {
        Task<DifficultyDto> AddAsync(DifficultyDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<DifficultyDto>> GetAll();
        Task<DifficultyDto> GetById(int entityId);
        Task<DifficultyDto> Update(DifficultyDto entityDto);
    }
}
