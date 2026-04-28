namespace Models.Entities
{
    public class Recipe : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreparationTime { get; set; }
        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = "Pending";
        public bool IsActive { get; set; } = true;
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public User User { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
