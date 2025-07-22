using Models.Entities;

namespace Models.Mappers
{
    public class DifficultyMapper
    {
        public static DifficultyDto ToDto(Difficulty entity)
        {
            if (entity == null)
                return null;

            return new DifficultyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsAtive = entity.IsAtive,
            };
        }
        public static IEnumerable<DifficultyDto> ToDtos(IEnumerable<Difficulty> entities)
        {
            if (entities == null)
                return Enumerable.Empty<DifficultyDto>();

            return entities.Select(e => ToDto(e));
        }
        public static Difficulty ToEntityAdd(DifficultyDto entityDto)
        {
            if (entityDto == null)
                return null;

            return new Difficulty
            {
                Name = entityDto.Name,
                IsAtive = entityDto.IsAtive,
            };
        }

        public static Difficulty ToEntityUpdate(DifficultyDto entityDto, Difficulty entity)
        {
            if (entityDto == null)
                return null;

            entity.Name = entityDto.Name;
            entity.IsAtive = entityDto.IsAtive;
            return entity;
        }
    }
}
