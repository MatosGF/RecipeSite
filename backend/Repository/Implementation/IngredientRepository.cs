using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;


namespace Repository.Implementation
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DbContextRecipe context)
           : base(context) { }


        public async Task<IEnumerable<Ingredient>> SearchByName(string name)
        {
            return await _context.Ingredients
                .Where(i => i.Name.Contains(name))
                .ToListAsync();
        }

    }
}
