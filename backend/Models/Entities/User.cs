namespace Models.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRegistered { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
        public virtual List<int> Favorites { get; set; }
        public virtual List<int> Recipes { get; set; }
    }
}
