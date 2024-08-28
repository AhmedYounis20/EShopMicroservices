using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQueryHandler(IApplicationDbContext dbContext): IQueryHandler<GetOrdersByCustomerQuery,GetOrdersByCustomerResult>
{
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders.Include(e => e.OrderItems).AsNoTracking()
            .Where(e => e.CustomerId == CustomerId.Of(query.CustomerId)).OrderBy(e => e.OrderName)
            .ToListAsync(cancellationToken);
        
        return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
    }
}