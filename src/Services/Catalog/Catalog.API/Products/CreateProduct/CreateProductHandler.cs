namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description, string ImagePath, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(e => e.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(e => e.ImagePath).NotEmpty().WithMessage("ImagePath is required");
            RuleFor(e => e.Price).GreaterThan(0).WithMessage("Price must be positive value");
        }   
    }
    internal class CreateProductCommandHandler (IDocumentSession session,ILogger<CreateProductCommandHandler> logger): ICommandHandler<CreateProductCommand,CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreateProductCommandHandler.Handle called with {@command}", command);

            // create Product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                ImageFile = command.ImagePath,
                Description = command.Description,
                Price = command.Price,
            };

            // save to database ToDo
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // return CreateProductResult result
            return new CreateProductResult(product.Id);

        }
    }
}
