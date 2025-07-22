namespace Models.Entities
{
    public class Rating : BaseModel
    {
        public decimal RatingValue { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
