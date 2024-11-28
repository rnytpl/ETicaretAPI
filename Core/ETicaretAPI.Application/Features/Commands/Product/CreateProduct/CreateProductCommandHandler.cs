using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.Application.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        // Write Repository
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductHubService _productHubService;
        // Validators
        readonly IValidator<CreateProductCommandRequest> _createProductValidator;



        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IValidator<CreateProductCommandRequest> createProductValidator, IProductHubService productHubService = null)
        {
            _productWriteRepository = productWriteRepository;
            _createProductValidator = createProductValidator;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = _createProductValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                //ValidationFailure error = validationResult.Errors.FirstOrDefault();
                string? error = validationResult?.Errors?.Select(error =>
                $"{error?.PropertyName}: {error?.ErrorMessage}"
                ).Aggregate((current,next) => $"\n{current} \n {next} \n");

                throw new Exception(error);

            }

            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });

            await _productWriteRepository.SaveAsync();
            await _productHubService.ProductAddedMessageAsync($"{request.Name} added.");

            return new CreateProductCommandResponse();
        }
    }
}
