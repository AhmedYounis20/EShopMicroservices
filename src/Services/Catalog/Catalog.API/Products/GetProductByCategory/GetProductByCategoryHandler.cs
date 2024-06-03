namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryQuery(string category) : IQuery<GetProductsByCagoryResult>;
public record GetProductsByCagoryResult(IEnumerable<Product> Products);
public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCagoryResult>
{
    public async Task<GetProductsByCagoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().Where(e=>e.Category.Contains(query.category)).ToListAsync(cancellationToken);
        
        return new GetProductsByCagoryResult(products);
    }
}