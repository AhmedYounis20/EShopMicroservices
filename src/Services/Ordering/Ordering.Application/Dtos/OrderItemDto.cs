using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record OrderItemDto(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal Price);
