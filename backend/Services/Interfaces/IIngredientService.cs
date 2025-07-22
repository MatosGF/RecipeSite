using Models;

namespace Service.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientDto> AddAsync(IngredientDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<IngredientDto>> GetAll();
        Task<IngredientDto> GetById(int entityId);
        Task<IngredientDto> Update(IngredientDto entityDto);
    }
}
