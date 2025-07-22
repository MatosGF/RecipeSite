using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _repository;
        private readonly ILogger<RatingService> _logger;
        public RatingService(IRatingRepository ratingRepository, ILogger<RatingService> logger)
        {
            _repository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<RatingDto> AddAsync(RatingDto entityDto)
        {
            try
            {
                var entity = RatingMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return RatingMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova avaliação");
                throw;
            }
        }
        public async Task<RatingDto> Update(RatingDto entityDto)
        {
            try
            {
                // Buscar o Rating pelo ID
                Rating entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Avaliação não encontrada.");
                }
                // Atualizar as informações
                entity = RatingMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return RatingMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<RatingDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return RatingMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Avaliação não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<RatingDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return RatingMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de avaliações não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar avaliação com ID {{ID}}", id);
                throw;
            }
        }

    }
}
