using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class CreateRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreparationTime { get; set; } // manter string para compatibilidade
        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }

        // UserId será preenchido no controller a partir do token
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public List<CreateRecipeIngredientDto> RecipeIngredients { get; set; } = new List<CreateRecipeIngredientDto>();

        public string Status { get; set; } = "Pending";
    }
}
