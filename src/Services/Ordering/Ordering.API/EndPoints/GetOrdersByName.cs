using BuildingBlocks.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.EndPoints;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
        {
            var query = new GetOrdersByNameQuery(orderName);

            var result = await sender.Send(query);


            return Results.Ok(result.Adapt<GetOrdersByNameResponse>());
        }) 
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders By Name")
        .WithDescription("Get Orders By Name endpoint");
    }
}