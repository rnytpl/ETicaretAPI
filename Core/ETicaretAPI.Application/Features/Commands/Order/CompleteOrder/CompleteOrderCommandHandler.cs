using ETicaretAPI.Application.Abstractions.Services;
using Appuser = ETicaretAPI.Domain.Entities.Identity.AppUser; 
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.Order.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IMailService _mailService;
        readonly UserManager<Appuser> _userManager;
        public CompleteOrderCommandHandler(IOrderService orderService, IMailService mailService,  UserManager<Appuser> userManager)
        {
            _orderService = orderService;
            _mailService = mailService;
            _userManager = userManager;
        }

        public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Appuser? user = await _userManager.FindByIdAsync(request.UserId);


            Domain.Entities.Order? result = await _orderService.CompleteOrderAsync(request.OrderId);

            await _mailService.SendCompletedOrderMailAsync(user?.Email, user?.UserName, result.OrderCode, result.CreatedDate, result.Address);

            return new();
        }
    }
}
