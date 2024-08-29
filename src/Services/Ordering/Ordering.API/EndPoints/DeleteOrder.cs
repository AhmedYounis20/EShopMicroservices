using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Orders.Commands.DeleteOrder;
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.EndPoints;

public record DeleteOrderResponse(bool IsSuccess);

public class DeleteOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{orderId}", async ([FromRoute]Guid orderId, ISender sender) =>
            {
                var command = new DeleteOrderCommand(orderId);

                var result = await sender.Send(command);
                var response = result.Adapt<DeleteOrderResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteOrder")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order endpoint with Delete request");
    }
}