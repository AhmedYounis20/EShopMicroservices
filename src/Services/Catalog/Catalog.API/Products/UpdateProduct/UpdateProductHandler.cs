namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductResult(bool IsSuccess);
public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImagePath, decimal Price) : ICommand<UpdateProductResult>;

public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException();

        product.Name = command.Name;
        product.Description = command.Description;
        product.Category = command.Category;
        product.Price = command.Price;
        product.ImageFile= command.ImagePath;

        session.Update<Product>(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}