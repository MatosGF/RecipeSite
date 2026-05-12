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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryService> _logger;
        private readonly DbContextRecipe _context;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger, DbContextRecipe context)
        {
            _repository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
                Category entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Categoria não encontrada.");
                }
                entity = CategoryMapper.ToEntityUpdate(entityDto, entity);

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
                    return false;

                var isUsed = await _context.Recipes
                    .AnyAsync(r => r.CategoryId == id);

                if (isUsed)
                    throw new InvalidOperationException(
                        "Não é possível deletar a categoria porque ele está sendo usado em receitas.");

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

    }
}
