using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, GetBasketItemsQueryResponse>
    {

        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<GetBasketItemsQueryResponse> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketItemsAsync();

            var basketItems = basket.BasketItems.Select(bi => new
            {
                BasketId = basket.Id.ToString(),
                BasketItemId = bi.Id.ToString(),
                BasketItemImage =
                bi.Product.ProductImageFiles?.FirstOrDefault()?.Path ?? string.Empty,
                Name = bi.Product.Name,
                Description = bi.Product.Description,
                Price = bi.Product.Price,
                Quantity = bi.Quantity
            })
                .ToList();

            return new()
            {
                BasketId = basket.Id.ToString(),
                BasketItems = basketItems
            };
        }
    }
}
