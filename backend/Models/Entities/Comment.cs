namespace Models.Entities
{
    public class Comment : BaseModel
    {
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
