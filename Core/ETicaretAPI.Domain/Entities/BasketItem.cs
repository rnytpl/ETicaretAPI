using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        // One
        public Basket Basket { get; set; }

        // One
        public Product Product { get; set; }
    }
}
