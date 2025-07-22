using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repository;
        private readonly ILogger<FavoriteService> _logger;

        public FavoriteService(IFavoriteRepository favoriteRepository, ILogger<FavoriteService> logger)
        {
            _repository = favoriteRepository ?? throw new ArgumentNullException(nameof(favoriteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FavoriteDto> AddAsync(FavoriteDto entityDto)
        {
            try
            {
                var entity = FavoriteMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return FavoriteMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar novo favorito");
                throw;
            }
        }

        public async Task<FavoriteDto> Update(FavoriteDto entityDto)
        {
            try
            {
                // Buscar o Favorite pelo ID
                Favorite entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Favorito não encontrada.");
                }
                // Atualizar as informações
                entity = FavoriteMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return FavoriteMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<FavoriteDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return FavoriteMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Favorito não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<FavoriteDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return FavoriteMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de favoritos não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar favorito com ID {{ID}}", id);
                throw;
            }
        }

    }
}
