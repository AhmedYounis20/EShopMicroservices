namespace Ordering.Application.Orders.Commands.UpdateOrder;


public record UpdateOrderCommand(OrderDto Order): ICommand<UpdateOrderResult>;
public record UpdateOrderResult(bool  IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(e => e.Order.OrderName).NotEmpty().WithMessage("OrderName is required");
        RuleFor(e => e.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(e => e.Order.Id).NotEmpty().WithMessage("Id is required");
    }
}