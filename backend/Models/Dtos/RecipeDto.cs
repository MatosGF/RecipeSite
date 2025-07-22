using Models.Entities;

namespace Models
{
    public class RecipeDto : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreparationTime { get; set; }
        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }
        public int UserId { get; set; }
        public CategoryDto Category { get; set; }
        public DifficultyDto Difficulty { get; set; }
        public UserDto User { get; set; }

    }
}
