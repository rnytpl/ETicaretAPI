using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Order
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, List<OrderListDTO>>
    {
        readonly IOrderService _orderService;

        public GetOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<OrderListDTO>> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetOrdersAsync();

            return result;
        }
    }
}
