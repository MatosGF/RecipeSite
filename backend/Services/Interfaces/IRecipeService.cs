using Models;

namespace Service.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> AddAsync(RecipeDto entityDto);
        //Task ApproveRecipe(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RecipeDto>> GetAll();
        Task<RecipeDto> GetById(int entityId);
        Task<IEnumerable<RecipeDto>> GetPendingRecipes();
        Task<RecipeDto> Update(RecipeDto entityDto);
    }
}
