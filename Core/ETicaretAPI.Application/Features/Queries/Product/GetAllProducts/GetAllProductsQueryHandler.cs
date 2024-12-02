using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {

        private readonly IProductReadRepository _productReadRepository;


        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {

            // Getting the total count of all entities exist in the table
            var totalCount = _productReadRepository.GetAll(false).Count();
            // Skips a calculated number of items based on the current page and page size, 
            // Takes the specified number of items for the current page.
            var products = _productReadRepository
                                .GetAll(false)
                                .OrderBy(p => p.CreatedDate)
                                .Select(p => new
                                    {
                                        p.Id,
                                        p.Name,
                                        p.Stock,
                                        p.Price,
                                        p.Description,
                                        createdDate = p.CreatedDate.ToString("dd/MM/yyyy                                HH:mm:ss.ff"),
                                        updatedDate = p.UpdatedDate.ToString("dd/MM/yyyy                                HH:mm:ss.ff"),
                                    })
                                .Skip((request.Page - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .ToList();

            decimal page = (decimal)totalCount / request.PageSize;
            var totalPages = Math.Ceiling(page);

            return new() { Products = products, TotalCount = totalCount, TotalPages = totalPages };
        }
    }
}
