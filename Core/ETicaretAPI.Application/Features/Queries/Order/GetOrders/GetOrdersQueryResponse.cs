using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryResponse
    {
        public int TotalPages { get; set; }
        public object Orders { get; set; }
    }
}
