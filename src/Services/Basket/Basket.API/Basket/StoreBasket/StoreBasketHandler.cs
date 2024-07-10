namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(e => e.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(e => e.Cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}
public record StoreBasketResult(string UserName);

public class StoreBasketCommandHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.StoreBasket(request.Cart, cancellationToken);
        return new StoreBasketResult(request.Cart.UserName);
    }
}