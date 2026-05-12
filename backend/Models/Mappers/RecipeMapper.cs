using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Dtos;
using Models.Entities;

public static class RecipeMapper
{
    public static RecipeDto ToDto(Recipe entity)
    {
        if (entity == null) return null;

        return new RecipeDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            PreparationTime = entity.PreparationTime,
            CategoryId = entity.CategoryId,
            DifficultyId = entity.DifficultyId,
            UserId = entity.UserId,
            IsActive = entity.IsActive,
            Status = entity.Status,
            ImageUrl = entity.ImageUrl,

            Category = entity.Category != null
                ? new CategoryDto { Id = entity.Category.Id, Name = entity.Category.Name }
                : null,

            Difficulty = entity.Difficulty != null
                ? new DifficultyDto { Id = entity.Difficulty.Id, Name = entity.Difficulty.Name }
                : null,

            User = entity.User != null
                ? new UserDto { Id = entity.User.Id, Name = entity.User.Name, Email = entity.User.Email }
                : null,

            AverageRating = (double)(entity.Ratings != null && entity.Ratings.Any()
                ? Math.Round(entity.Ratings.Average(r => r.RatingValue), 1)
                : 0),

            RatingsCount = entity.Ratings?.Count ?? 0,

            RecipeIngredients = entity.RecipeIngredients != null
                ? entity.RecipeIngredients.Select(ri => new RecipeIngredientDto
                {
                    Id = ri.Id,
                    Amount = ri.Amount,
                    IngredientId = ri.IngredientId,
                    MeasurementTypeId = ri.MeasurementTypeId,

                    Ingredient = ri.Ingredient != null
                        ? new IngredientDto
                        {
                            Id = ri.Ingredient.Id,
                            Name = ri.Ingredient.Name
                        }
                        : null,

                    MeasurementType = ri.MeasurementType != null
                        ? new MeasurementTypeDto
                        {
                            Id = ri.MeasurementType.Id,
                            Name = ri.MeasurementType.Name
                        }
                        : null
                }).ToList()
                : new List<RecipeIngredientDto>()
        };
    }


    public static Recipe ToEntityAdd(RecipeDto dto)
    {
        if (dto == null) return null;

        return new Recipe
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            DifficultyId = dto.DifficultyId,
            PreparationTime = dto.PreparationTime,
            UserId = dto.UserId,
            IsActive = dto.IsActive,
            Status = dto.Status ?? "Pending",
            ImageUrl = dto.ImageUrl,
            RecipeIngredients = dto.RecipeIngredients?.Select(ri => new RecipeIngredient
            {
                IngredientId = ri.IngredientId,
                MeasurementTypeId = ri.MeasurementTypeId,
                Amount = ri.Amount
            }).ToList()
        };
    }

    public static Recipe ToEntityUpdate(RecipeDto dto, Recipe entity)
    {
        if (dto == null) return entity;

        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.CategoryId = dto.CategoryId;
        entity.DifficultyId = dto.DifficultyId;
        entity.PreparationTime = dto.PreparationTime;
        entity.ImageUrl = dto.ImageUrl;
        entity.Status = dto.Status;
        entity.IsActive = dto.IsActive;

        if (dto.RecipeIngredients != null)
        {
            entity.RecipeIngredients.Clear();

            foreach (var ri in dto.RecipeIngredients)
            {
                entity.RecipeIngredients.Add(new RecipeIngredient
                {
                    IngredientId = ri.IngredientId,
                    MeasurementTypeId = ri.MeasurementTypeId,
                    Amount = ri.Amount
                });
            }
        }

        return entity;
    }


    public static IEnumerable<RecipeDto> ToDtos(IEnumerable<Recipe> entities)
    {
        if (entities == null)
            return Enumerable.Empty<RecipeDto>();

        return entities.Select(ToDto).ToList();
    }



    public static Recipe ToEntityAdd(CreateRecipeDto dto)
    {
        if (dto == null) return null;

        return new Recipe
        {
            Title = dto.Title,
            Description = dto.Description,
            PreparationTime = dto.PreparationTime,
            CategoryId = dto.CategoryId,
            DifficultyId = dto.DifficultyId,
            UserId = dto.UserId, 
            Status = dto.Status ?? "Pending",
            ImageUrl = dto.ImageUrl,
            RecipeIngredients = dto.RecipeIngredients?.Select(ri => new RecipeIngredient
            {
                IngredientId = ri.IngredientId,
                MeasurementTypeId = ri.MeasurementTypeId,
                Amount = Convert.ToInt32(ri.Amount)
            }).ToList()
        };
    }
}

