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
                Favorite entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Favorito não encontrada.");
                }
                entity = FavoriteMapper.ToEntityUpdate(entityDto, entity);

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

        public async Task<bool> Toggle(int userId, int recipeId)
        {
            var favorite = await _repository.GetByUserAndRecipe(userId, recipeId);

            if (favorite == null)
            {
                await _repository.AddAsync(new Favorite
                {
                    UserId = userId,
                    RecipeId = recipeId,
                    IsActive = true
                });

                await _repository.SaveAsync();
                return true; 
            }

            _repository.Delete(favorite);
            await _repository.SaveAsync();
            return false; 
        }

        public async Task<bool> IsFavorite(int userId, int recipeId)
        {
            return await _repository.GetByUserAndRecipe(userId, recipeId) != null;
        }

        public async Task<IEnumerable<FavoriteRecipeDto>> GetMyFavorites(int userId)
        {
            var favorites = await _repository.GetByUserId(userId);

            return favorites.Select(f => new FavoriteRecipeDto
            {
                RecipeId = f.RecipeId,
                Title = f.Recipe.Title,
                ImageUrl = f.Recipe.ImageUrl,
                AverageRating = (double)(f.Recipe.Ratings.Any()
                    ? Math.Round(f.Recipe.Ratings.Average(r => r.RatingValue), 1)
                    : 0)
            });
        }

    }
}
