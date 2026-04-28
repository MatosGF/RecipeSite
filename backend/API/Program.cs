
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Repository.Context;
using Repository.Implementation;
using Repository.Interfaces;
using Service.Implementation;
using Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MasterChef Recipe API",
                    Version = "v1",
                    Description = "API para gerenciamento de receitas, com upload de imagens"
                });
                c.EnableAnnotations();
            });

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

            var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });


            builder.Services.AddDbContext<DbContextRecipe>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options => options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterChef Recipe API v1");
                });
            }

            app.UseDeveloperExceptionPage();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")),
                RequestPath = "/uploads"
            });

            app.MapControllers();

            Console.WriteLine("App iniciada");
            app.Run();
        }
    }
}
