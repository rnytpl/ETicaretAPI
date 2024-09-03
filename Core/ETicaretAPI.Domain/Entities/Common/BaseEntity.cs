using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    /// <summary>
    /// Every class derives from BaseEntity inherits below method signatures
    /// </summary>
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        // Can be overriden in derived classes
        virtual public DateTime UpdatedDate { get; set; } 

    }
}
