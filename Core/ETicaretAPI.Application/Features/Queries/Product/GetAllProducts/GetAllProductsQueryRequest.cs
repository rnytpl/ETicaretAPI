using ETicaretAPI.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
