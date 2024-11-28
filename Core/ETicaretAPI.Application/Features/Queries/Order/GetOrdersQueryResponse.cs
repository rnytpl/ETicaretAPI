using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Features.Queries.Order
{
    public class GetOrdersQueryResponse
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string OrderCode { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
