using Models.Entities;
using Repository.Context;
using Repository.Interfaces;


namespace Repository.Implementation
{
    public class DifficultyRepository : GenericRepository<Difficulty>, IDifficultyRepository
    {
        public DifficultyRepository(DbContextRecipe context)
           : base(context) { }

    }
}
