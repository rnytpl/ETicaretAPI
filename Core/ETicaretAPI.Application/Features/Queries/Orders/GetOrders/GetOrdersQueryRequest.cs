using ETicaretAPI.Application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryRequest : IRequest<GetOrdersQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
    }
}
