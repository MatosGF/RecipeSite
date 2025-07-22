using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CategoryDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false)
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
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsAtive = table.Column<bool>(type: "bit", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_MeasurementTypes_MeasurementTypeId",
                table: "RecipeIngredients",
                column: "MeasurementTypeId",
                principalTable: "MeasurementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
