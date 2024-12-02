using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueryResponse
    {
        public string BasketId { get; set; }
        public string BasketItemId { get; set; }
        public string BasketItemImage { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
