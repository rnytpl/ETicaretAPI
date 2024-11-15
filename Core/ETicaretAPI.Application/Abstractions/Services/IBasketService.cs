using ETicaretAPI.Application.DTOs.Baskets;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(CreateBasketItem BasketItem);
        public Task UpdateQuantityAsync(UpdateBasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
    }
}
