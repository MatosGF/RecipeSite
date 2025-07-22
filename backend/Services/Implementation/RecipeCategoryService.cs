using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IRecipeCategoryRepository _repository;
        private readonly ILogger<RecipeCategoryService> _logger;
        public RecipeCategoryService(IRecipeCategoryRepository recipeCategoryRepository, ILogger<RecipeCategoryService> logger)
        {
            _repository = recipeCategoryRepository ?? throw new ArgumentNullException(nameof(recipeCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<RecipeCategoryDto> AddAsync(RecipeCategoryDto entityDto)
        {
            try
            {
                var entity = RecipeCategoryMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return RecipeCategoryMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova categoria de receita");
                throw;
            }
        }
        public async Task<RecipeCategoryDto> Update(RecipeCategoryDto entityDto)
        {
            try
            {
                // Buscar o RecipeCategory pelo ID
                RecipeCategory entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Categoria de receita não encontrada.");
                }
                // Atualizar as informações
                entity = RecipeCategoryMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return RecipeCategoryMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<RecipeCategoryDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return RecipeCategoryMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Categoria de receita não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeCategoryDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return RecipeCategoryMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de categorias de receita não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar categoria de receita com ID {{ID}}", id);
                throw;
            }
        }

    }
}
