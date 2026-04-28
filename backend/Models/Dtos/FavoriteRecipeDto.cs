using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FavoriteRecipeDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public double AverageRating { get; set; }
    }
}
