using Models;

namespace Service.Interfaces
{
    public interface IRecipeCategoryService
    {
        Task<RecipeCategoryDto> AddAsync(RecipeCategoryDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RecipeCategoryDto>> GetAll();
        Task<RecipeCategoryDto> GetById(int entityId);
        Task<RecipeCategoryDto> Update(RecipeCategoryDto entityDto);
    }
}
