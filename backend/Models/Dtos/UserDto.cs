using Models.Entities;

namespace Models
{
    public class UserDto : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRegistered { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public virtual List<int> Favorites { get; set; } = new();
        public virtual List<int> Recipes { get; set; } = new();
    }
}
