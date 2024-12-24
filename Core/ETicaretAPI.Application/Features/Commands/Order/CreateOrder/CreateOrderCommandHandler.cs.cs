using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IOrderService _orderService;
        readonly IBasketService _basketService;
        readonly IOrderHubService _orderHubService;
        readonly IMailService _mailService;

        public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService, IHttpContextAccessor httpContextAccessor, IMailService mailService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _orderHubService = orderHubService;
            _httpContextAccessor = httpContextAccessor;
            _mailService = mailService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            string? username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

            var result = await _orderService.CreateOrderAsync(request);

            if (result ) await _orderHubService.OrderCreatedMessageAsync(username, "New order inbound");

            return new() { Result = result };
        }
    }
}
