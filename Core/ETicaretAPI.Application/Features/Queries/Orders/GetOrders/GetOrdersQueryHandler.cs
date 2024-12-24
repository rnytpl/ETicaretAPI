using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
        readonly IOrderService _orderService;

        public GetOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {


            var result = await _orderService.GetOrdersAsync(request.Page, request.PageSize);


            var totalPages = (int)Math.Ceiling((decimal)result.TotalOrderCount / request.PageSize);

            return new() { Orders = result, TotalPages = totalPages };
        }
    }
}
