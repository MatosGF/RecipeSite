using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Implementation
{
    public class DifficultyService : IDifficultyService
    {
        private readonly IDifficultyRepository _repository;
        private readonly ILogger<DifficultyService> _logger;

        public DifficultyService(IDifficultyRepository difficultyRepository, ILogger<DifficultyService> logger)
        {
            _repository = difficultyRepository ?? throw new ArgumentNullException(nameof(difficultyRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DifficultyDto> AddAsync(DifficultyDto entityDto)
        {
            try
            {
                var entity = DifficultyMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return DifficultyMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova dificuldade");
                throw;
            }
        }

        public async Task<DifficultyDto> Update(DifficultyDto entityDto)
        {
            try
            {
                // Buscar o Difficulty pelo ID
                Difficulty entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Dificuldade não encontrada.");
                }
                // Atualizar as informações
                entity = DifficultyMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return DifficultyMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<DifficultyDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return DifficultyMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dificuldade não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<DifficultyDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return DifficultyMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de dificuldades não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar dificuldade com ID {{ID}}", id);
                throw;
            }
        }

    }
}
