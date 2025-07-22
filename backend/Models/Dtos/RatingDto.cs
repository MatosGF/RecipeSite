using Models.Entities;

namespace Models
{
    public class RatingDto : BaseModel
    {
        public decimal RatingValue { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
