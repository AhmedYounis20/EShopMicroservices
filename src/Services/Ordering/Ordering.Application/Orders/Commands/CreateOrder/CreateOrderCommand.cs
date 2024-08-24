namespace Ordering.Application.Orders.Commands.CreateOrder;


public record CreateOrderCommand(OrderDto order): ICommand<CreateOrderResult>;
public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(e => e.order.OrderName).NotEmpty().WithMessage("OrderName is required");
        RuleFor(e => e.order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(e => e.order.OrderItems).NotEmpty().WithMessage("OrderItems shouldn't be empty");
    }
}