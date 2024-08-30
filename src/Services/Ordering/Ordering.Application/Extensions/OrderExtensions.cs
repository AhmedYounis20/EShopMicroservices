namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
        => orders.Select(e => e.ToOrderDto()).ToList();

    public static OrderDto ToOrderDto(this Order order)
        => FromOrderToDto(order);
    private static OrderDto FromOrderToDto(Order e)
        => new OrderDto(e.Id.Value,
            e.CustomerId.Value,
            e.OrderName.Value,
            new AddressDto(e.ShippingAddress.FirstName,
                e.ShippingAddress.LastName,
                e.ShippingAddress.EmailAddress,
                e.ShippingAddress.AddressLine,
                e.ShippingAddress.Country,
                e.ShippingAddress.State,
                e.ShippingAddress.ZipCode),
            new AddressDto(e.BillingAddress.FirstName,
                e.BillingAddress.LastName,
                e.BillingAddress.EmailAddress,
                e.BillingAddress.AddressLine,
                e.BillingAddress.Country,
                e.BillingAddress.State,
                e.BillingAddress.ZipCode),
            new PaymentDto(e.Payment.CardName,
                e.Payment.CardNumber,
                e.Payment.Expiration,
                e.Payment.Cvv,
                e.Payment.PaymentMethod),
            e.Status,
            e.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value, oi.ProductId.Value, oi.Quantity, oi.Price))
                .ToList());
}