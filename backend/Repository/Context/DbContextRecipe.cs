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
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingredient>()
                .HasMany<RecipeIngredient>()
                .WithOne(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeasurementType>()
                .HasMany<RecipeIngredient>()
                .WithOne(ri => ri.MeasurementType)
                .HasForeignKey(ri => ri.MeasurementTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany()
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Difficulty)
                .WithMany()
                .HasForeignKey(r => r.DifficultyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Recipe)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Recipe)
                .WithMany(r => r.Favorites)
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }


    }
}
