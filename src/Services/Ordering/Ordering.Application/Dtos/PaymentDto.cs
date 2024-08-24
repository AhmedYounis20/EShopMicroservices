using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record PaymentDto(
    string CardName,
    string Cardnumber,
    string Expiration,
    string Cvv,
    int PaymentMethod);