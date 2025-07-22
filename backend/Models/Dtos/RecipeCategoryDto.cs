using Models.Entities;

namespace Models
{
    public class RecipeCategoryDto : BaseModel
    {
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
