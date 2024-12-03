using ETicaretAPI.Application.DTOs.Baskets;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<Basket> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(CreateBasketItem BasketItem);
        public Task UpdateQuantityAsync(UpdateBasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
        public Basket? GetActiveUserBasket { get; }
    }
}
