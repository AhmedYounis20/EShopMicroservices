namespace Catalog.API.Products.CreateProduct;

public record UpdateProductRequest(string Name, List<string> Category, string Description, string ImagePath, decimal Price);
public record UpdateProductResponse(bool isSuccess);
public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{id}", async (Guid id, UpdateProductRequest request, ISender sender) =>
        {


            var command = new UpdateProductCommand(id, request.Name, request.Category, request.Description, request.ImagePath, request.Price);

            var result = await sender.Send(command);



            return Results.Ok(new UpdateProductResponse(result.IsSuccess));
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Product ya basha")
        .WithDescription("Khalas ba2a");
    }
}
