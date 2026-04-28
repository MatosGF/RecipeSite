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
                LastName = entity.LastName,
                Phone = entity.Phone,
                Location = entity.Location,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin,
                IsBlocked = entity.IsBlocked,
                IsRegistered = entity.IsRegistered,
                IsActive = entity.IsActive
            };
        }


        public static IEnumerable<UserDto> ToDto(IEnumerable<User> entities)
        {
            if (entities == null)
                return Enumerable.Empty<UserDto>();

            return entities.Select(ToDto);
        }

        public static User ToEntityAdd(UserDto dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                IsAdmin = dto.IsAdmin,
                IsBlocked = dto.IsBlocked,
                IsRegistered = dto.IsRegistered,
                IsActive = dto.IsActive
                // Password será tratada no Service (hash)
            };
        }

        public static User ToEntityUpdate(UserDto dto, User entity)
        {
            if (dto == null || entity == null)
                return entity;

            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.IsAdmin = dto.IsAdmin;
            entity.IsBlocked = dto.IsBlocked;
            entity.IsRegistered = dto.IsRegistered;
            entity.IsActive = dto.IsActive;

            return entity;
        }
    }
}

