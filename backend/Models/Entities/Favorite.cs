namespace Models.Entities
{
    public class Favorite : BaseModel
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public bool IsActive { get; set; } = true;
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
