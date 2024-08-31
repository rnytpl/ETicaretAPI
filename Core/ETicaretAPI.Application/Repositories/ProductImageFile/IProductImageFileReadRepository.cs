using F = ETicaretAPI.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;

namespace ETicaretAPI.Application.Repositories.ProductImageFile
{
    public interface IProductImageFileReadRepository : IReadRepository<F.ProductImageFile>
    {
    }
}
