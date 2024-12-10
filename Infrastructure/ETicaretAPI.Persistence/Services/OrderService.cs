using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.CompletedOrder;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
        readonly ICompletedOrderReadRepository _completedOrderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _completedOrderWriteRepository = completedOrderWriteRepository;
            _completedOrderReadRepository = completedOrderReadRepository;
        }

        public async Task CreateOrderAsync(CreateOrderCommandRequest request)
        {

            var orderCode = new Random().Next(1000000, 10000000).ToString();

            await _orderWriteRepository.AddAsync(new()
            {
                Address = request.Address,
                Description = request.Description,
                Id = Guid.Parse(request.BasketId),
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


            var data = query.Skip((page -1) * pageSize).Take(pageSize);

            var data2 = from order in data
                        join completedOrder in _completedOrderReadRepository.Table
                            on order.Id equals completedOrder.OrderId into co
                        from _co in co.DefaultIfEmpty()
                        select new
                        {
                            Id = order.Id,
                            CreatedDate = order.CreatedDate.ToString("dd/MM/yyyy hh:mm:ss"),
                            OrderCode = order.OrderCode,
                            Basket = order.Basket,
                            UserId = order.Basket.User.Id,
                            Completed = _co != null ? true : false,
                            Address = order.Address,
                            Description = order.Description,
                        };

            var totalOrderCount = await query.CountAsync();

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data2.Select(o => new
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    CreatedDate = o.CreatedDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Quantity * bi.Product.Price),
                    UserName = o.Basket.User.UserName,
                    Address = o.Address,
                    Description = o.Description,
                    o.Completed,
                }).ToListAsync(),
            };
        }

        public async Task<SingleOrder> GetOrderByIdAsync(string orderId)
        {
            var result = await _orderReadRepository.Table
                            .Include(o => o.Basket)
                                .ThenInclude(b => b.BasketItems)
                                    .ThenInclude(bi => bi.Product)
                                        .ThenInclude(p => p.ProductImageFiles)
                            .Include(o => o.CompletedOrder)
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
                CreatedDate = result.CreatedDate.ToString("dd/MM/yy hh:mm:ss"),
                Description = result.Description,
                OrderCode = result.OrderCode,
                UserName = result?.Basket?.User?.UserName,
                Completed = result.CompletedOrder != null ? true : false,
            };
        }

        public async Task CompleteOrderAsync(string Id)
        {
            Order order = await _orderReadRepository.GetByIdAsync(Id);

            if (order != null)
            {
                await _completedOrderWriteRepository.AddAsync(new()
                {
                    OrderId = Guid.Parse(Id),
                });
                await _completedOrderWriteRepository.SaveAsync();
            }
        }
    }
}
