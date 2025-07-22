using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;

namespace Repository.Context
{
    public class DbContextRecipe : DbContext
    {
        public DbContextRecipe(DbContextOptions<DbContextRecipe> options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // There's a chance for you to need to define some FK, PK , essas cenas de DB
            // If so, ask for help at "" INTERNET "" (if you know what I mean)

            //InitialLoadData.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
