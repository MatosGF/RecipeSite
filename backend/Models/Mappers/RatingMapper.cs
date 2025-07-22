using Models.Entities;

namespace Models.Mappers
{
    public class RatingMapper
    {
        public static RatingDto ToDto(Rating entity)
        {
            if (entity == null)
                return null;

            return new RatingDto
            {
                Id = entity.Id,
                RatingValue = entity.RatingValue,
                RecipeId = entity.RecipeId,
                UserId = entity.UserId,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<RatingDto> ToDtos(IEnumerable<Rating> entities)
        {
            if (entities == null)
                return Enumerable.Empty<RatingDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Rating ToEntityAdd(RatingDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Rating
            {
                RatingValue = entityDto.RatingValue,
                RecipeId = entityDto.RecipeId,
                UserId = entityDto.UserId,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static Rating ToEntityUpdate(RatingDto entityDto, Rating entity)
        {
            if (entityDto == null)
                return null;

            entity.RatingValue = entityDto.RatingValue;
            entity.RecipeId = entityDto.RecipeId;
            entity.UserId = entityDto.UserId;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
