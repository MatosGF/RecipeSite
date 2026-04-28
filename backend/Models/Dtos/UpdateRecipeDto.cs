using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string PreparationTime { get; set; }

        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }

        public string ImageUrl { get; set; }

        public List<CreateRecipeIngredientDto> RecipeIngredients { get; set; }
            = new List<CreateRecipeIngredientDto>();
    }
}
