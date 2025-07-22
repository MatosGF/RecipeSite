namespace Models.Entities
{
    public class Favorite : BaseModel
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
