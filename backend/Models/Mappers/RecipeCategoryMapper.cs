using Models.Entities;

namespace Models.Mappers
{
    public class RecipeCategoryMapper
    {
        public static RecipeCategoryDto ToDto(RecipeCategory entity)
        {
            if (entity == null)
                return null;

            return new RecipeCategoryDto
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Category = entity.Category,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<RecipeCategoryDto> ToDtos(IEnumerable<RecipeCategory> entities)
        {
            if (entities == null)
                return Enumerable.Empty<RecipeCategoryDto>();

            return entities.Select(e => ToDto(e));
        }
        public static RecipeCategory ToEntityAdd(RecipeCategoryDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new RecipeCategory
            {
                CategoryId = entityDto.CategoryId,
                Category = entityDto.Category,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static RecipeCategory ToEntityUpdate(RecipeCategoryDto entityDto, RecipeCategory entity)
        {
            if (entityDto == null)
                return null;

            entity.CategoryId = entityDto.CategoryId;
            entity.Category = entityDto.Category;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
