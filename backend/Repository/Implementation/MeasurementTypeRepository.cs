using Models.Entities;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class MeasurementTypeRepository : GenericRepository<MeasurementType>, IMeasurementTypeRepository
    {
        public MeasurementTypeRepository(DbContextRecipe context)
           : base(context) { }

    }
}
