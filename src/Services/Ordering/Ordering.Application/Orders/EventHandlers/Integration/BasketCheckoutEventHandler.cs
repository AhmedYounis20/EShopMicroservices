using BuildingBlocks.Messaging.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Application.Orders.EventHandlers.Domain;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ILogger<BasketCheckoutEventHandler> logger,ISender sender) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntergrationEvent}",context);
        var command = MapToCreateCommand(context.Message);
        await sender.Send(command);
    }

    private CreateOrderCommand MapToCreateCommand(BasketCheckoutEvent message)
    {
        AddressDto addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress,
            message.AddressLine, message.Country, message.State, message.ZipCode);
        PaymentDto paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.Cvv,
            message.PaymentMethod);
        var orderId = Guid.NewGuid();
        var orderDto = new OrderDto(
            orderId,
            message.CustomerId,
            message.UserName,
            addressDto,
            addressDto,
            paymentDto,
            Ordering.Domain.Enums.OrderStatus.Pending,
            [
                new OrderItemDto(orderId, new Guid("C67D6323-E8B1-4BDF-9A75-B0D0D2E7E914"), 2, 500),
                new OrderItemDto(orderId, new Guid("4F136E9F-FF8C-4C1F-9A33-D12F689BDAB8"), 1, 400),
            ]
        );

        return new CreateOrderCommand(orderDto);
    }
}