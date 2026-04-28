namespace Models.Entities
{
    public class Rating : BaseModel
    {
        public decimal RatingValue { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
