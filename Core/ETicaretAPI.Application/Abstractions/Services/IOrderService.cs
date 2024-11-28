using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Queries.Order;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<List<OrderListDTO>> GetOrdersAsync();
        Task CreateOrderAsync(CreateOrderDTO createOrder);
    }
}
