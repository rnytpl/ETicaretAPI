using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetAllProductsImages
{
    public class GetAllProductsImagesQueryRequest : IRequest<GetAllProductsImagesQueryResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
