using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Baskets;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        public BasketService(IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository)
        {
            _httpContextAccessor = contextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketReadRepository = basketReadRepository;
        }

        private async Task<Basket?> ContextUser()
        {
            string? username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                                    .Include(u => u.Baskets)
                                        .ThenInclude(b => b.BasketItems)
                                            .ThenInclude(bi => bi.Product)
                                                .ThenInclude(p => p.ProductImageFiles)
                                    .FirstOrDefaultAsync(u => u.UserName == username);


                var _basket =   // Retrieve a user's existing baskets
                                from basket in user?.Baskets
                                // Join Basket and Order 
                                join order in _orderReadRepository.Table
                                // Match basketId with orderId and group results into BasketOrders          collection
                                on basket.Id equals order.Id into BasketOrders
                                // If a basket has no associated order, ensure Basket is included in        the result with order being null
                                from order in BasketOrders.DefaultIfEmpty()
                                // Project the results into an anonymous type
                                select new {
                                    Basket = basket,
                                    Order = order
                                };

                Basket? targetBasket = null;

                if (_basket.Any(b => b.Order is null))

                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;

                else
                {
                    targetBasket = new();
                    user?.Baskets.Add(targetBasket);
                };

                await _basketItemWriteRepository.SaveAsync();

                return targetBasket;

            }

            throw new Exception("An unexpected error occured");

        }
        public async Task AddItemToBasketAsync(CreateBasketItem BasketItem)
        {
            Basket? basket = await ContextUser();

            if (basket != null)
            {
               BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(BasketItem.ProductId));

                if (_basketItem != null)
                    _basketItem.Quantity++;
                else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(BasketItem.ProductId),
                        Quantity = BasketItem.Quantity,
                    });

                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task<Basket> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();

            Basket? result = await _basketReadRepository.Table
                .Where(b => b.Id == basket.Id)
                .Select(b => new Basket
                    {
                        Id = b.Id,
                        BasketItems = b.BasketItems.Select(bi => new BasketItem
                        {
                            Id = bi.Id,
                            Quantity = bi.Quantity,
                            Product = new Product
                            {
                                Id = bi.Product.Id,
                                Name = bi.Product.Name,
                                Price = bi.Product.Price,
                                Description = bi.Product.Description,
                                ProductImageFiles = bi.Product.ProductImageFiles.Select(pif => new ProductImageFile
                                {
                                    Path = pif.Path
                                }).ToList(),

                            }
                        }).ToList()
                    }
                )
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);

            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);

                await _basketItemWriteRepository.SaveAsync();
            }

        }

        public async Task UpdateQuantityAsync(UpdateBasketItem basketItem)
        {
            BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);

            if (_basketItem != null)
            {
                if (basketItem.Quantity == 0)
                {
                    _basketItemWriteRepository.Remove(_basketItem);
                }
                else
                {
                    _basketItem.Quantity = basketItem.Quantity;
                }
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public Basket? GetActiveUserBasket
        {
            get { 
            Basket? basket = ContextUser().Result;

            return basket;
            }
        }
    }
}
 