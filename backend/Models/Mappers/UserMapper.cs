using Models.Entities;

namespace Models.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User entity)
        {
            if (entity == null)
                return null;

            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Favorites = entity.Favorites,
                IsAdmin = entity.IsAdmin,
                IsAtive = entity.IsAtive,
                IsRegistered = entity.IsRegistered,
                Recipes = entity.Recipes,
            };
        }

        public static IEnumerable<UserDto> ToDto(IEnumerable<User> entities)
        {
            if (entities == null)
                return Enumerable.Empty<UserDto>();

            return entities.Select(e => ToDto(e));
        }

        public static User ToEntityAdd(UserDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new User
            {
                Name = entityDto.Name,
                Email = entityDto.Email,
                Favorites = entityDto.Favorites,
                IsAdmin = entityDto.IsAdmin,
                IsAtive = entityDto.IsAtive,
                IsRegistered = entityDto.IsRegistered,
                Recipes = entityDto.Recipes,
            };
        }

        public static User ToEntityUpdate(UserDto entityDto, User entity)
        {
            if (entityDto == null)
                return null;

            entity.Name = entityDto.Name;
            entity.Email = entityDto.Email;
            entity.Favorites = entityDto.Favorites;
            entity.IsAdmin = entityDto.IsAdmin;
            entity.IsAtive = entityDto.IsAtive;
            entity.IsRegistered = entityDto.IsRegistered;
            entity.Recipes = entityDto.Recipes;
            return entity;
        }
    }
}
