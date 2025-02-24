namespace Ordering.Application.Orders.Queries.GetOrdersByCostumer
{
    public record GetOrdersByCostumerQuery(Guid customerId): IQuery<GetOrdersByCustomerResult>;
    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);

}
