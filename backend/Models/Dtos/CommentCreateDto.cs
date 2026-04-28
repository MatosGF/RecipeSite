using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class CommentCreateDto
    {
        public string Comments { get; set; }
        public int RecipeId { get; set; }
    }
}
