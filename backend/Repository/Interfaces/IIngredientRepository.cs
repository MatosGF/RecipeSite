using Models;
using Models.Entities;


namespace Repository.Interfaces
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> SearchByName(string name);
    }
}
