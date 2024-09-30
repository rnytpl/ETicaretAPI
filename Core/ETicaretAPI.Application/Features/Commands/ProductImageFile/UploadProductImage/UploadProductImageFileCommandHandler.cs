using Product = ETicaretAPI.Domain.Entities.Product;
using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    internal class UploadProductImageFileCommandHandler : IRequestHandler<UploadProductImageFileCommandRequest, UploadProductImageFileCommandResponse>
    {
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IStorageService _storageService;

        public UploadProductImageFileCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository = null, IStorageService storageService = null)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productReadRepository = productReadRepository;
            _storageService = storageService;
        }

        public async Task<UploadProductImageFileCommandResponse> Handle(UploadProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathorContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            ETicaretAPI.Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.ProductId);

            await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ETicaretAPI.Domain.Entities.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathorContainerName,
                Storage = _storageService.StorageName,
                Products = new List<ETicaretAPI.Domain.Entities.Product>() { product }

            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();

            return new UploadProductImageFileCommandResponse();
        }
    }
}
