using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
