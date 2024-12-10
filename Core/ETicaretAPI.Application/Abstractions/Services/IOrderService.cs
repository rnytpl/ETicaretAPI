using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<OrderListDTO> GetOrdersAsync(int Page, int PageSize);
        Task CreateOrderAsync(CreateOrderCommandRequest request);
        Task<SingleOrder> GetOrderByIdAsync(string orderId);
        Task CompleteOrderAsync(string Id);

    }
}
