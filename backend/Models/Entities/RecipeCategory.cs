namespace Models.Entities
{
    public class RecipeCategory : BaseModel
    {
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
