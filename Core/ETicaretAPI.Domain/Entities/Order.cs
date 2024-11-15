using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        // One to one
        public Basket Basket { get; set; }
        // Many to many
        public ICollection<Product>? Products { get; set; }

        // One to Many
        public Customer Customer { get; set; }
    }
}
