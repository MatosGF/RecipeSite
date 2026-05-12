using Microsoft.Extensions.Logging;
using Models;
using Models.Dtos;
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
        public async Task<RecipeDto> AddAsync(CreateRecipeDto dto)
        {
            try
            {
                var entity = new Recipe
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    PreparationTime = dto.PreparationTime,
                    CategoryId = dto.CategoryId,
                    DifficultyId = dto.DifficultyId,
                    UserId = dto.UserId,
                    ImageUrl = dto.ImageUrl,
                    Status = "Pending",
                    IsActive = true,
                    RecipeIngredients = dto.RecipeIngredients.Select(ri => new RecipeIngredient
                    {
                        IngredientId = ri.IngredientId,
                        MeasurementTypeId = ri.MeasurementTypeId,
                        Amount = (int)ri.Amount
                    }).ToList()
                };

                await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                var dtoFinal = RecipeMapper.ToDto(entity);

                return dtoFinal;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar nova receita");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetApprovedRecipes()
        {
            var recipes = await _repository.GetApprovedRecipes();
            return RecipeMapper.ToDtos(recipes);
        }



        public async Task<RecipeDto> Update(UpdateRecipeDto dto)
        {
            var entity = await _repository.GetByIdWithIngredientsAsync(dto.Id);

            if (entity == null)
                throw new InvalidOperationException("Receita não encontrada.");

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.PreparationTime = dto.PreparationTime;
            entity.CategoryId = dto.CategoryId;
            entity.DifficultyId = dto.DifficultyId;
            entity.ImageUrl = dto.ImageUrl;

            entity.RecipeIngredients.Clear();

            foreach (var ing in dto.RecipeIngredients)
            {
                entity.RecipeIngredients.Add(new RecipeIngredient
                {
                    IngredientId = ing.IngredientId,
                    MeasurementTypeId = ing.MeasurementTypeId,
                    Amount = (int)ing.Amount
                });
            }

            await _repository.Update(entity);
            await _repository.SaveAsync();

            return RecipeMapper.ToDto(entity);
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
                var entities = await _repository.GetAllAsync();
                return RecipeMapper.ToDtos(entities); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todas as receitas");
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

        public async Task ApproveRecipe(int id)
        {
            try
            {
                await _repository.ApproveRecipe(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao tentar aprovar receita com ID {{ID}}", id);
                throw;
            }

        }

        public async Task<IEnumerable<RecipeDto>> GetPendingRecipes()
        {
            try
            {
                var recipes = await _repository.GetPendingRecipes();
                return RecipeMapper.ToDtos(recipes); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar receitas pendentes");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeDto>> SearchRecipes(string? search)
        {
            var recipes = await _repository.SearchRecipes(search);
            return RecipeMapper.ToDtos(recipes);
        }

    }
}
