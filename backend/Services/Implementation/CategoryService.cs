//using Service.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _repository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CategoryDto> AddAsync(CategoryDto entityDto)
        {
            try
            {
                var entity = CategoryMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return CategoryMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova categoria");
                throw;
            }
        }

        public async Task<CategoryDto> Update(CategoryDto entityDto)
        {
            try
            {
                // Buscar o Category pelo ID
                Category entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Categoria não encontrada.");
                }
                // Atualizar as informações
                entity = CategoryMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return CategoryMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<CategoryDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return CategoryMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Categoria não encontrada.");
                throw;
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return CategoryMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de categorias não encontrada.");
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
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar categoria com ID {{ID}}", id);
                throw;
            }
        }

    }
}
