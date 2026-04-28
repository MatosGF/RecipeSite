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
            // Relacionamento Recipe -> RecipeIngredient
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento Ingredient -> RecipeIngredient
            modelBuilder.Entity<Ingredient>()
                .HasMany<RecipeIngredient>()
                .WithOne(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento MeasurementType -> RecipeIngredient
            modelBuilder.Entity<MeasurementType>()
                .HasMany<RecipeIngredient>()
                .WithOne(ri => ri.MeasurementType)
                .HasForeignKey(ri => ri.MeasurementTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
