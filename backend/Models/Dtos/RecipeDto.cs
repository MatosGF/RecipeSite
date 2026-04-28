using Models.Entities;
using System.Collections.Generic;

namespace Models
{
    public class RecipeDto : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreparationTime { get; set; }  
        public string Status { get; set; }
        public bool IsActive { get; set; } 
        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }

        public double AverageRating { get; set; }
        public int RatingsCount { get; set; }


        public CategoryDto Category { get; set; }
        public DifficultyDto Difficulty { get; set; }
        public UserDto User { get; set; }

        public List<RecipeIngredientDto> RecipeIngredients { get; set; } = new List<RecipeIngredientDto>();
    }
}

