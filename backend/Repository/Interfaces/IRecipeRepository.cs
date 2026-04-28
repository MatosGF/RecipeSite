using Models.Entities;


namespace Repository.Interfaces
{
    public interface IRecipeRepository : IGenericRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetPendingRecipes();
        Task ApproveRecipe(int recipeId);
        Task<Recipe> GetByIdWithIngredientsAsync(int id);
        Task<IEnumerable<Recipe>> GetApprovedRecipes();
        Task<IEnumerable<Recipe>> SearchRecipes(string? search);

    }
}
