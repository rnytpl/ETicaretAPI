using ETicaretAPI.Application.Repositories;
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
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        // Write Repository
        readonly IProductWriteRepository _productWriteRepository;
        // Validators
        readonly IValidator<CreateProductCommandRequest> _createProductValidator;
        


        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IValidator<CreateProductCommandRequest> createProductValidator)
        {
            _productWriteRepository = productWriteRepository;
            _createProductValidator = createProductValidator;
        
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = _createProductValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                //var errors = validationResult.Errors.ForEach(e =>  new ValidationFailure() { PropertyName = e.PropertyName, ErrorMessage= e.ErrorMessage});
                //return new CreateProductCommandResponse() { ValidationErrors = errors };
                //return new()
                //{
                //    ErrorMessage = validationResult.Errors.First().ErrorMessage,
                //};

                throw new ValidationException(message: "Validation errror"); 
            }

            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });

            await _productWriteRepository.SaveAsync();

            return new CreateProductCommandResponse();
        }
    }
}
