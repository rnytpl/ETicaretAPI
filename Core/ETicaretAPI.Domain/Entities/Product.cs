using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }

        // Many to many
        //public ICollection<Order> Orders { get; set; }

        // A product can have a collection of product image files
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }

        // A product can exist in just more than one basket
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
