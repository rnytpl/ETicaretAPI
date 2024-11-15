using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        // Links Basket to a specific User
        public string UserId { get; set; }

        // Gives access to Order entity
        public Order Order { get; set; }
        // Gives access to User identity
        public AppUser User { get; set; }

        // A basket can contain many basket items
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
