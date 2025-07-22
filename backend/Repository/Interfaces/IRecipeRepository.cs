using Models.Entities;


namespace Repository.Interfaces
{
    public interface IRecipeRepository : IGenericRepository<Recipe>
    {
        //Task ApproveRecipe(int recipeId);
        Task<IEnumerable<Recipe>> GetPendingRecipes();
    }
}
