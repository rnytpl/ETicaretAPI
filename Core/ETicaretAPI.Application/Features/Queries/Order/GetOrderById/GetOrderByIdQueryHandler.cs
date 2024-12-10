using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System.Management;

namespace ETicaretAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {

        readonly IOrderService _orderService;
        public GetOrderByIdQueryHandler(IOrderService orderService = null)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _orderService.GetOrderByIdAsync(request.OrderId);

            return new()
            {
                Id = data.Id,
                Description = data.Description,
                OrderCode = data.OrderCode,
                BasketItems = data.BasketItems,
                CreatedDate = data.CreatedDate,
                Address = data.Address,
                UserName = data.UserName,
                Completed = data.Completed,
            };
        }
    }
}
