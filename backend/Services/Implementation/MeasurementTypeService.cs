using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class MeasurementTypeService : IMeasurementTypeService
    {
        private readonly IMeasurementTypeRepository _repository;
        private readonly ILogger<MeasurementTypeService> _logger;
        public MeasurementTypeService(IMeasurementTypeRepository measurementTypeRepository, ILogger<MeasurementTypeService> logger)
        {
            _repository = measurementTypeRepository ?? throw new ArgumentNullException(nameof(measurementTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<MeasurementTypeDto> AddAsync(MeasurementTypeDto entityDto)
        {
            try
            {
                var entity = MeasurementTypeMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return MeasurementTypeMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar novo tipo de medição");
                throw;
            }
        }
        public async Task<MeasurementTypeDto> Update(MeasurementTypeDto entityDto)
        {
            try
            {
                // Buscar o MeasurementType pelo ID
                MeasurementType entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Tipo de medição não encontrada.");
                }
                // Atualizar as informações
                entity = MeasurementTypeMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return MeasurementTypeMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<MeasurementTypeDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return MeasurementTypeMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tipo de medição não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<MeasurementTypeDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return MeasurementTypeMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de tipo de medição não encontrada.");
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _repository.Delete(entity);
                await _repository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar tipo de medição com ID {{ID}}", id);
                throw;
            }
        }

    }
}