using Models.Entities;

namespace Models.Mappers
{
    public class IngredientMapper
    {
        public static IngredientDto ToDto(Ingredient entity)
        {
            if (entity == null)
                return null;

            return new IngredientDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<IngredientDto> ToDtos(IEnumerable<Ingredient> entities)
        {
            if (entities == null)
                return Enumerable.Empty<IngredientDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Ingredient ToEntityAdd(IngredientDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Ingredient
            {
                Name = entityDto.Name,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static Ingredient ToEntityUpdate(IngredientDto entityDto, Ingredient entity)
        {
            if (entityDto == null)
                return null;

            entity.Name = entityDto.Name;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
