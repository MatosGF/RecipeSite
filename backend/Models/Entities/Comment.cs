namespace Models.Entities
{
    public class Comment : BaseModel
    {
        public string Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
