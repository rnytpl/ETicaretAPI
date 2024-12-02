using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Queries.Order;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<OrderListDTO> GetOrdersAsync(int page, int pageSize)

         {
            var query = _orderReadRepository.Table
                            .Include(o => o.Basket)
                                .ThenInclude(b => b.User)
                            .Include(o => o.Basket)
                                .ThenInclude(b => b.BasketItems)
                                .ThenInclude(bi => bi.Product);

            var data = await query
                        .Select(o => new
                            {
                                Description = o.Description,
                                Address = o.Address,
                                Id = o.Id,
                                CreatedDate = o.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss.ff"),
                                OrderCode = o.OrderCode,
                                TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price                            * bi.Quantity),
                                UserName = o.Basket.User.UserName,
                                UserId = o.Basket.User.Id,
                            }
                        )
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            var totalOrderCount = await query.CountAsync();

            return new()
            {
                TotalOrderCount = totalOrderCount,
                Orders = data,
            };
        }

        public async Task<SingleOrder> GetOrderByIdAsync(string orderId)
        {
            var result = await _orderReadRepository.Table
                            .Include(o => o.Basket)
                                .ThenInclude(b => b.BasketItems)
                                    .ThenInclude(bi => bi.Product)
                                        .ThenInclude(p => p.ProductImageFiles)
                            .Include(o => o.Basket.User)
                                            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(orderId));

            return new ()
            {
                Id = result.Id.ToString(),
                BasketItems = result.Basket.BasketItems.Select(bi => new
                {
                    bi.ProductId,
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity,
                    ProductImagePath = bi.Product.ProductImageFiles.FirstOrDefault(pif => pif.Path != null)?.Path,

                }),
                Address = result.Address,
                CreatedDate = result.CreatedDate,
                Description = result.Description,
                OrderCode = result.OrderCode,
                UserName = result?.Basket?.User?.UserName,
            };
        }
    }
}
