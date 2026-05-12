using Models;
using Models.Entities;

namespace Models.Mappers
{
    public class RecipeIngredientMapper
    {
        public static RecipeIngredientDto ToDto(RecipeIngredient entity)
        {
            if (entity == null)
                return null;

            return new RecipeIngredientDto
            {
                Id = entity.Id,
                Amount = entity.Amount,
                IngredientId = entity.IngredientId,
                MeasurementTypeId = entity.MeasurementTypeId,
                IsActive = entity.IsActive,

                Ingredient = entity.Ingredient != null
                    ? new IngredientDto
                    {
                        Id = entity.Ingredient.Id,
                        Name = entity.Ingredient.Name
                    }
                    : null,

                MeasurementType = entity.MeasurementType != null
                    ? new MeasurementTypeDto
                    {
                        Id = entity.MeasurementType.Id,
                        Name = entity.MeasurementType.Name
                    }
                    : null
            };
        }

        public static IEnumerable<RecipeIngredientDto> ToDtos(IEnumerable<RecipeIngredient> entities)
        {
            if (entities == null)
                return Enumerable.Empty<RecipeIngredientDto>();

            return entities.Select(ToDto);
        }

        public static RecipeIngredient ToEntityAdd(RecipeIngredientDto dto)
        {
            if (dto == null)
                return null;

            return new RecipeIngredient
            {
                Amount = dto.Amount,
                IngredientId = dto.IngredientId,
                MeasurementTypeId = dto.MeasurementTypeId,
                IsActive = dto.IsActive                
            };
        }

        public static RecipeIngredient ToEntityUpdate(RecipeIngredientDto dto, RecipeIngredient entity)
        {
            if (dto == null)
                return entity;

            entity.Amount = dto.Amount;
            entity.IngredientId = dto.IngredientId;
            entity.MeasurementTypeId = dto.MeasurementTypeId;
            entity.IsActive = dto.IsActive;

            return entity;
        }
    }
}


