using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/categories/{id}", async (int id, ICategoryService categoryService) =>
            {
                CategoryDTO? dto = await categoryService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCategory")
            .Produces<CategoryDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/categories", async (ICategoryService categoryService) =>
            {
                var dtos = await categoryService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllCategories")
            .Produces<List<CategoryDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/categories", async (CategoryDTO dto, ICategoryService categoryService) =>
            {
                try
                {
                    CategoryDTO categoryDTO = await categoryService.AddAsync(dto);

                    return Results.Created($"/categories/{categoryDTO.Id}", categoryDTO);
                }
                catch (ArgumentException ex)
                {
                    // TODO: Delete internal error messages leaks
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCategory")
            .Produces<CategoryDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/categories", async (CategoryDTO dto, ICategoryService categoryService) =>
            {
                try
                {
                    var found = await categoryService.UpdateAsync(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    // TODO: Delete internal error messages leaks
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateCategory")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/categories/{id}", async (int id, ICategoryService categoryService) =>
            {
                var deleted = await categoryService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCategory")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
