using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Queries.Order;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<OrderListDTO> GetOrdersAsync(int Page, int PageSize);
        Task CreateOrderAsync(CreateOrderDTO createOrder);
        Task<SingleOrder> GetOrderByIdAsync(string orderId);
    }
}
