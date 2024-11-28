using ETicaretAPI.Application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Order
{
    public class GetOrdersQueryRequest : IRequest<List<OrderListDTO>>
    {
        public string Page { get; set; }
        public string PageSize { get; set; }
    }
}
