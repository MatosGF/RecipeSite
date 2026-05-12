using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Context;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Implementation
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;
        private readonly ILogger<IngredientService> _logger;
        private readonly DbContextRecipe _context;
        public IngredientService(IIngredientRepository ingredientRepository,ILogger<IngredientService> logger, DbContextRecipe context)
        {
            _repository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IngredientDto> AddAsync(IngredientDto entityDto)
        {
            try
            {
                var entity = IngredientMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return IngredientMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar novo tipo de medição");
                throw;
            }
        }
        public async Task<IngredientDto> Update(IngredientDto entityDto)
        {
            try
            {
                Ingredient entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Tipo de medição não encontrada.");
                }
                entity = IngredientMapper.ToEntityUpdate(entityDto, entity);

                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return IngredientMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<IngredientDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return IngredientMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tipo de medição não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<IngredientDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return IngredientMapper.ToDtos(entity);
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
                    return false;

                var isUsed = await _context.RecipeIngredients
                .AnyAsync(ri => ri.IngredientId == id);

                if (isUsed)
                    throw new InvalidOperationException(
                        "Não é possível deletar o ingrediente porque ele está sendo usado em receitas.");

                _repository.Delete(entity);
                await _repository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar categoria com ID {ID}", id);
                throw;
            }
        }

        public async Task<IEnumerable<IngredientDto>> SearchByName(string name)
        {
            var items = await _repository.SearchByName(name);
            return IngredientMapper.ToDtos(items);
        }
    }
}
