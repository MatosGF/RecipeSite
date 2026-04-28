using Models.Entities;

namespace Models
{
    public class UserDto : BaseModel
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsRegistered { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
    }
}
