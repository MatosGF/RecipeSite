using Models.Entities;
using Repository.Context;
using Repository.Interfaces;


namespace Repository.Implementation
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DbContextRecipe context)
           : base(context) { }

    }
}
