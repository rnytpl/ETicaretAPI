using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<OrderListDTO> GetOrdersAsync(int Page, int PageSize);
        Task<bool> CreateOrderAsync(CreateOrderCommandRequest request);
        Task<SingleOrder> GetOrderByIdAsync(string orderId);
        Task<Order> CompleteOrderAsync(string Id);

    }
}
