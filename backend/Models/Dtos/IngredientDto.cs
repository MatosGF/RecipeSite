using Models.Entities;

namespace Models
{
    public class IngredientDto : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
