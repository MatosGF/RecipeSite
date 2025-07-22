using Models.Entities;

namespace Models
{
    public class RecipeIngredientDto : BaseModel
    {
        public int Amount { get; set; }
        public int MeasurementTypeId { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public MeasurementTypeDto MeasurementType { get; set; }
        public IngredientDto Ingredient { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}
