using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Queries.Order;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task CreateOrderAsync(CreateOrderDTO createOrder)
        {

            var orderCode = new Random().Next(1000000, 10000000).ToString();

            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Description = createOrder.Description,
                Id = Guid.Parse(createOrder.BasketId),
                OrderCode = orderCode
            });

            await _orderWriteRepository.SaveAsync();
        }

        public async Task<List<OrderListDTO>> GetOrdersAsync()
        {
            //List<GetOrdersQueryResponse> response = await _orderReadRepository
            //    .GetAll(false)
            //    .Select(o => new GetOrdersQueryResponse() { Address = o.Address, Description = o.Description, UserId = o.Basket.User.UserName, OrderCode = o.OrderCode, BasketItems = o.Basket.BasketItems.ToList()})
            //    .ToListAsync();

            var response = await _orderReadRepository.Table
                .Include(o => o.Basket)
                    .ThenInclude(b => b.User)
                .Include(o => o.Basket)
                    .ThenInclude(b => b.BasketItems)
                    .ThenInclude(bi => bi.Product)
                .Select(o => new OrderListDTO { 
                    Address = o.Address,
                    Description = o.Description,
                    BasketItems = o.Basket.BasketItems.ToList(),
                    CreatedDate = o.CreatedDate,
                    UpdatedDate = o.UpdatedDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity)
                })
                .ToListAsync();

            return response;

        }

    }
}
