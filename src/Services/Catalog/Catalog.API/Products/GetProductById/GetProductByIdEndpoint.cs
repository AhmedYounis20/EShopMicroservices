﻿namespace Catalog.API.Products.CreateProduct;

public record GetProductByIdResponse(Product? Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id,ISender sender) =>
        {

            var command = new GetProductByIdQuery(id);

            var result = await sender.Send(command);

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product ya basha")
        .WithDescription("Khalas ba2a");
    }
}