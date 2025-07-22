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
                Ingredient = entity.Ingredient,
                IngredientId = entity.IngredientId,
                MeasurementType = entity.MeasurementType,
                MeasurementTypeId = entity.MeasurementTypeId,
                RecipeId = entity.RecipeId,
                Recipe = entity.Recipe,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<RecipeIngredientDto> ToDtos(IEnumerable<RecipeIngredient> entities)
        {
            if (entities == null)
                return Enumerable.Empty<RecipeIngredientDto>();

            return entities.Select(e => ToDto(e));
        }
        public static RecipeIngredient ToEntityAdd(RecipeIngredientDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new RecipeIngredient
            {
                Amount = entityDto.Amount,
                Ingredient = entityDto.Ingredient,
                IngredientId = entityDto.IngredientId,
                MeasurementType = entityDto.MeasurementType,
                IsAtive = entityDto.IsAtive,
                MeasurementTypeId = entityDto.MeasurementTypeId,
                RecipeId = entityDto.RecipeId,
                Recipe = entityDto.Recipe,
            };
        }

        public static RecipeIngredient ToEntityUpdate(RecipeIngredientDto entityDto, RecipeIngredient entity)
        {
            if (entityDto == null)
                return null;

            entity.Amount = entityDto.Amount;
            entity.Ingredient = entityDto.Ingredient;
            entity.IngredientId = entityDto.IngredientId;
            entity.MeasurementType = entityDto.MeasurementType;
            entity.IsAtive = entityDto.IsAtive;
            entity.MeasurementTypeId = entityDto.MeasurementTypeId;
            entity.RecipeId = entityDto.RecipeId;
            entity.Recipe = entityDto.Recipe;
            return entity;
        }
    }
}
