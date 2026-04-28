using Models;
using Models.Dtos;

namespace Service.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> AddAsync(CreateRecipeDto dto);
        Task ApproveRecipe(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RecipeDto>> GetAll();
        Task<RecipeDto> GetById(int entityId);
        Task<IEnumerable<RecipeDto>> GetPendingRecipes();
        Task<RecipeDto> Update(UpdateRecipeDto dto);
        Task<IEnumerable<RecipeDto>> GetApprovedRecipes();
        Task<IEnumerable<RecipeDto>> SearchRecipes(string? search);
    }
}
