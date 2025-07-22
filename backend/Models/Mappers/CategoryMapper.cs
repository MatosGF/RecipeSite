using Models.Entities;

namespace Models.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto ToDto(Category entity)
        {
            if (entity == null)
                return null;

            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<CategoryDto> ToDtos(IEnumerable<Category> entities)
        {
            if (entities == null)
                return Enumerable.Empty<CategoryDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Category ToEntityAdd(CategoryDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Category
            {
                Name = entityDto.Name,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static Category ToEntityUpdate(CategoryDto entityDto, Category entity)
        {
            if (entityDto == null)
                return null;

            entity.Name = entityDto.Name;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
