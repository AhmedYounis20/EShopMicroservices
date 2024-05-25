namespace Catalog.API.Products;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product? Product);

public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> _logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductByIdHandler.Handle called with {@request}", request);

        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException();

        return  new GetProductByIdResult(product);
    }
}