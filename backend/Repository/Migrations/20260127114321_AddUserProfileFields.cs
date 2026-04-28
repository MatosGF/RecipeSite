using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfileFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_CategoryDto_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_IngredientDto_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_MeasurementTypeDto_MeasurementTypeId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_RecipeDto_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_CategoryDto_CategoryId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DifficultyDto_DifficultyId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientDto");

            migrationBuilder.DropTable(
                name: "MeasurementTypeDto");

            migrationBuilder.DropTable(
                name: "RecipeDto");

            migrationBuilder.DropTable(
                name: "CategoryDto");

            migrationBuilder.DropTable(
                name: "DifficultyDto");

            migrationBuilder.RenameColumn(
                name: "IsRegisted",
                table: "Users",
                newName: "IsRegistered");

            migrationBuilder.RenameColumn(
                name: "Favourites",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Measurement",
                table: "MeasurementTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UsertId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Favorites",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RecipeId",
                table: "Ratings",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeId",
                table: "Comments",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                table: "Comments",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Recipes_RecipeId",
                table: "Favorites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Recipes_RecipeId",
                table: "Ratings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_MeasurementTypes_MeasurementTypeId",
                table: "RecipeIngredients",
                column: "MeasurementTypeId",
                principalTable: "MeasurementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Difficulties_DifficultyId",
                table: "Recipes",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Recipes_RecipeId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Recipes_RecipeId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_MeasurementTypes_MeasurementTypeId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Difficulties_DifficultyId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RecipeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipeId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Favorites",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "Favourites");

            migrationBuilder.RenameColumn(
                name: "IsRegistered",
                table: "Users",
                newName: "IsRegisted");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MeasurementTypes",
                newName: "Measurement");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UsertId");

            migrationBuilder.CreateTable(
                name: "CategoryDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypeDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypeDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false),
                    PreparationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDto_CategoryDto_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDto_DifficultyDto_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "DifficultyDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDto_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDto_CategoryId",
                table: "RecipeDto",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDto_DifficultyId",
                table: "RecipeDto",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDto_UserId",
                table: "RecipeDto",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_CategoryDto_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "CategoryDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_IngredientDto_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "IngredientDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_MeasurementTypeDto_MeasurementTypeId",
                table: "RecipeIngredients",
                column: "MeasurementTypeId",
                principalTable: "MeasurementTypeDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_RecipeDto_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "RecipeDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_CategoryDto_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "CategoryDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DifficultyDto_DifficultyId",
                table: "Recipes",
                column: "DifficultyId",
                principalTable: "DifficultyDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
