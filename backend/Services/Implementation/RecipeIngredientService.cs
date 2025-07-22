using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly ILogger<RecipeIngredientService> _logger;
        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, ILogger<RecipeIngredientService> logger)
        {
            _recipeIngredientRepository = recipeIngredientRepository ?? throw new ArgumentNullException(nameof(recipeIngredientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<RecipeIngredientDto> AddAsync(RecipeIngredientDto recipeIngredientDto)
        {
            try
            {
                var entity = RecipeIngredientMapper.ToEntityAdd(recipeIngredientDto);
                var entitySaved = await _recipeIngredientRepository.AddAsync(entity);
                await _recipeIngredientRepository.SaveAsync();

                return RecipeIngredientMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar novo ingrediente de receita");
                throw;
            }
        }
        public async Task<RecipeIngredientDto> Update(RecipeIngredientDto entityDto)
        {
            try
            {
                // Buscar o RecipeIngredient pelo ID
                RecipeIngredient entity = await _recipeIngredientRepository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Ingrediente da receita não encontrado.");
                }
                // Atualizar as informações
                entity = RecipeIngredientMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _recipeIngredientRepository.Update(entity);
                await _recipeIngredientRepository.SaveAsync();
                return RecipeIngredientMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<RecipeIngredientDto> GetById(int recipeIngredientId)
        {
            try
            {
                var entity = await _recipeIngredientRepository.GetByIdAsync(recipeIngredientId);
                return RecipeIngredientMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ingrediente de receita não encontrado.");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeIngredientDto>> GetAll()
        {
            try
            {
                var entity = await _recipeIngredientRepository.GetAllAsync();
                return RecipeIngredientMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de Ingrediente de receita não encontrada.");
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _recipeIngredientRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _recipeIngredientRepository.Delete(entity);
                await _recipeIngredientRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar ingrediente de receita com ID {{ID}}", id);
                throw;
            }
        }

    }
}
