using Models.Entities;

namespace Models.Mappers
{
    public class CommentMapper
    {
        public static CommentDto ToDto(Comment entity)
        {
            if (entity == null)
                return null;

            return new CommentDto
            {
                Id = entity.Id,
                Comments = entity.Comments,
                RecipeId = entity.RecipeId,
                UserId = entity.UserId,
                IsActive = entity.IsActive,
            };
        }
        public static IEnumerable<CommentDto> ToDtos(IEnumerable<Comment> entities)
        {
            if (entities == null)
                return Enumerable.Empty<CommentDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Comment ToEntityAdd(CommentDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Comment
            {
                Comments = entityDto.Comments,
                RecipeId = entityDto.RecipeId,
                UserId = entityDto.UserId,
                IsActive = entityDto.IsActive,
            };
        }

        public static Comment ToEntityUpdate(CommentDto entityDto, Comment entity)
        {
            if (entityDto == null)
                return null;

            entity.Comments = entityDto.Comments;
            entity.RecipeId = entityDto.RecipeId;
            entity.UserId = entityDto.UserId;
            entity.IsActive = entityDto.IsActive;
            return entity;
        }
    }
}
