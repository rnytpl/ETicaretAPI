using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ETicaretAPI.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        // Write Repository
        readonly IProductWriteRepository _productWriteRepository;
        // Validators
        readonly IValidator<CreateProductCommandRequest> _createProductValidator;
        readonly IValidator<VM_Update_Product> _updateProductValidator;


        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createProductValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                
                throw new Exception(validationResult.Errors.ToString()); 
            }

            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });

            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
