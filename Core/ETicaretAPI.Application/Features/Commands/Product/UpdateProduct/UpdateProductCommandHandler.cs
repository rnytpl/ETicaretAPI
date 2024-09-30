using ETicaretAPI.Application.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {

        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IValidator<UpdateProductCommandRequest> _updateProductValidator;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IValidator<UpdateProductCommandRequest> updateProductValidator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _updateProductValidator = updateProductValidator;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
