
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implementation;
using Repository.Interfaces;
using Service.Implementation;
using Service.Interfaces;


namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IDifficultyService, DifficultyService>();
            builder.Services.AddScoped<IFavoriteService, FavoriteService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IMeasurementTypeService, MeasurementTypeService>();
            builder.Services.AddScoped<IRatingService, RatingService>();
            builder.Services.AddScoped<IRecipeCategoryService, RecipeCategoryService>();
            builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
            builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IMeasurementTypeRepository, MeasurementTypeRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();
            builder.Services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();
            builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<DbContextRecipe>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseCors("AllowAll");


            app.UseAuthorization();


            app.MapControllers();

            Console.WriteLine("App iniciada");
            app.Run();
        }
    }
}
