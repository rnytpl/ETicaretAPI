using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string? OrderCode { get; set; }

        // One to one
        // Navigation Property
        // An order can be associated with one Basket
        public Basket Basket { get; set; }
    }
}
