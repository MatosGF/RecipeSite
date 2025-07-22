using Models;

namespace Service.Interfaces
{
    public interface IMeasurementTypeService
    {
        Task<MeasurementTypeDto> AddAsync(MeasurementTypeDto entityDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<MeasurementTypeDto>> GetAll();
        Task<MeasurementTypeDto> GetById(int entityId);
        Task<MeasurementTypeDto> Update(MeasurementTypeDto entityDto);
    }
}
