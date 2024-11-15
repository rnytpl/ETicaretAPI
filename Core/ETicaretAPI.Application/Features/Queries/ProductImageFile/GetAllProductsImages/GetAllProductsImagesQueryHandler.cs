using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetAllProductsImages
{
    public class GetAllProductsImagesQueryHandler : IRequestHandler<GetAllProductsImagesQueryRequest, GetAllProductsImagesQueryResponse>
    {
        readonly IStorageService _storageService;
        readonly IProductReadRepository _productReadRepository;
        readonly IConfiguration _configuration;

        public GetAllProductsImagesQueryHandler(IStorageService storageService, IProductReadRepository productReadRepository = null, IConfiguration configuration = null)
        {
            _storageService = storageService;
            _productReadRepository = productReadRepository;
            _configuration = configuration;
        }

        public async Task<GetAllProductsImagesQueryResponse> Handle(GetAllProductsImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProductCount = _productReadRepository.GetAll(false).Count();



            var products = _productReadRepository.GetAll(false)
                .OrderBy(p => p.CreatedDate)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(p => p.ProductImageFiles)
                .Select(p => new Products()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CreatedDate = p.CreatedDate,
                    ProductImages = p.ProductImageFiles.Select(p => new ProductImages()
                    {
                        Path = $"{_configuration["BaseStorageURl"]}{p.Path}",
                        FileName = p.FileName,
                    }).ToList(),
                }).ToList();
             

            decimal page = (decimal)totalProductCount / request.PageSize;
            var totalPages = Math.Ceiling(page);

            return new()
            {
                Products = products,
                TotalPages = totalPages,
                TotalProductCount = totalProductCount
            };
        }
    }
}
