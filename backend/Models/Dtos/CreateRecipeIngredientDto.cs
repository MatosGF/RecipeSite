namespace Models.Dtos
{
    public class CreateRecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public int MeasurementTypeId { get; set; }
        public double Amount { get; set; } 
    }
}

