using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.EndPoints;

public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/Customer/{customerId}", async (Guid customerId, ISender sender) =>
            {
                var query = new GetOrdersByCustomerQuery(customerId);

                var result = await sender.Send(query);


                return Results.Ok(result.Adapt<GetOrdersByCustomerResponse>());
            }) 
            .WithName("GetOrdersByCustomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Orders By Customer")
            .WithDescription("Get Orders By Customer endpoint");
    }
}