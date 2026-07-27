using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/categories", async () =>
            {
                CategoryService categoryService = new CategoryService();
                var dtos = await categoryService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllCategories")
            .Produces<List<CategoryDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
