using Models.Entities;

namespace Models
{
    public class FavoriteDto : BaseModel
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
