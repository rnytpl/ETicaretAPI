using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.ProductImageFile
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IConfiguration _configuration;


        public GetProductImagesQueryHandler(IProductImageFileReadRepository productImageFileReadRepository, IProductReadRepository productReadRepository, IConfiguration configuration)
        {
            _productImageFileReadRepository = productImageFileReadRepository;
            _productReadRepository = productReadRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.ProductId));

            
               return product.ProductImageFiles.Select(p => new GetProductImagesQueryResponse
                {
                    FileName = p.FileName,
                    Path = $"{_configuration["BaseStorageURl"]}{p.Path}",
                    Id = p.Id
                }).ToList();
            
        }
    }
}
