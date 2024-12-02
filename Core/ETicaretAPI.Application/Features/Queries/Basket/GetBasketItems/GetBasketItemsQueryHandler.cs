using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
    {

        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketItemsAsync();

            return basket.BasketItems.Select(bi => new GetBasketItemsQueryResponse {
                BasketId = basket.Id.ToString(),
                BasketItemId = bi.Id.ToString(),
                BasketItemImage = 
                bi.Product.ProductImageFiles?.FirstOrDefault()?.Path ?? string.Empty,
                Name = bi.Product.Name,
                Description = bi.Product.Description,
                Price = bi.Product.Price,
                Quantity = bi.Quantity })
                .ToList(); 

        }
    }
}
