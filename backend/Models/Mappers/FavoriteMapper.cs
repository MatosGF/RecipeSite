using Models.Entities;

namespace Models.Mappers
{
    public class FavoriteMapper
    {
        public static FavoriteDto ToDto(Favorite entity)
        {
            if (entity == null)
                return null;

            return new FavoriteDto
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                UserId = entity.UserId,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<FavoriteDto> ToDtos(IEnumerable<Favorite> entities)
        {
            if (entities == null)
                return Enumerable.Empty<FavoriteDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Favorite ToEntityAdd(FavoriteDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Favorite
            {
                RecipeId = entityDto.RecipeId,
                UserId = entityDto.UserId,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static Favorite ToEntityUpdate(FavoriteDto entityDto, Favorite entity)
        {
            if (entityDto == null)
                return null;

            entity.RecipeId = entityDto.RecipeId;
            entity.UserId = entityDto.UserId;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
