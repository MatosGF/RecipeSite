using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly ILogger<RecipeService> _logger;
        public RecipeService(IRecipeRepository recipeIngredientRepository, ILogger<RecipeService> logger)
        {
            _repository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<RecipeDto> AddAsync(RecipeDto entityDto)
        {
            try
            {
                var entity = RecipeMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return RecipeMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova receita");
                throw;
            }
        }
        public async Task<RecipeDto> Update(RecipeDto entityDto)
        {
            try
            {
                // Buscar o Recipe pelo ID
                Recipe entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Receita não encontrado.");
                }
                // Atualizar as informações
                entity = RecipeMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return RecipeMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<RecipeDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return RecipeMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Receita não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return RecipeMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de receita não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar receita com ID {{ID}}", id);
                throw;
            }
        }

        //public async Task ApproveRecipe(int id)
        //{
        //    try
        //    {
        //        await _repository.ApproveRecipe(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Ocorreu um erro ao tentar aprovar receita com ID {{ID}}", id);
        //        throw;
        //    }

        //}

        public async Task<IEnumerable<RecipeDto>> GetPendingRecipes()
        {
            try
            {
                var recipes = await _repository.GetPendingRecipes();
                return RecipeMapper.ToDtos(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de receita pendentes não encontrada.");
                throw;
            }

        }
    }
}
