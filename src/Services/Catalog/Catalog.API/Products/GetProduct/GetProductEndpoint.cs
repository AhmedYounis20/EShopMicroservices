namespace Catalog.API.Products.CreateProduct;

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {

            var command = new GetProductsQuery();

            var result = await sender.Send(command);

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Create Product ya basha")
        .WithDescription("Khalas ba2a");
    }
}