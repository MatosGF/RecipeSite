using Models;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddAsync(CategoryDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int entityId);
        Task<CategoryDto> Update(CategoryDto entityDto);
    }
}
