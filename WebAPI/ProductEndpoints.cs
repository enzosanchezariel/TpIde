using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/products/{id}", async (int id, IProductService productService) =>
            {
                ProductDTO? dto = await productService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetProduct")
            .Produces<ProductDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/products", async (IProductService productService) =>
            {
                var dtos = await productService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllProducts")
            .Produces<List<ProductDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/products", async (ProductDTO dto, IProductService productService) =>
            {
                try
                {
                    ProductDTO productDTO = await productService.AddAsync(dto);

                    return Results.Created($"/products/{productDTO.Id}", productDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddProduct")
            .Produces<ProductDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/products", async (ProductDTO dto, IProductService productService) =>
            {
                try
                {
                    var found = await productService.UpdateAsync(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateProduct")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/products/{id}", async (int id, IProductService productService) =>
            {
                var deleted = await productService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
