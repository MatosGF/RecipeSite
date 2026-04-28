using Models;
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
                Category = entity.Category != null ? new CategoryDto
                {
                    Id = entity.Category.Id,
                    Name = entity.Category.Name
                } : null
            };
        }

        public static IEnumerable<RecipeCategoryDto> ToDtos(IEnumerable<RecipeCategory> entities)
        {
            if (entities == null)
                return Enumerable.Empty<RecipeCategoryDto>();

            return entities.Select(e => ToDto(e));
        }

        public static RecipeCategory ToEntityAdd(RecipeCategoryDto dto)
        {
            if (dto == null)
                return null;

            return new RecipeCategory
            {
                
                Category = dto.Category != null ? new Category
                {
                    Id = dto.Category.Id,
                    Name = dto.Category.Name
                } : null
            };
        }

        public static RecipeCategory ToEntityUpdate(RecipeCategoryDto dto, RecipeCategory entity)
        {
            if (dto == null)
                return entity;


            entity.Category = dto.Category != null ? new Category
            {
                Id = dto.Category.Id,
                Name = dto.Category.Name
            } : null;

            return entity;
        }
    }
}

