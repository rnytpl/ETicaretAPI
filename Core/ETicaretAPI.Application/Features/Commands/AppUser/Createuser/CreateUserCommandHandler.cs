using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Application.Validators.Users;
using FluentValidation;
using FluentValidation.Results;
using MediatR;


namespace ETicaretAPI.Application.Features.Commands.AppUser.Createuser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IValidator<CreateUserCommandRequest> _validator;

        public CreateUserCommandHandler(IUserService userService, IValidator<CreateUserCommandRequest> validator = null)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                //ValidationFailure error = validationResult.Errors.FirstOrDefault();
                string error = validationResult?.Errors?.Select(error =>
                $"{error?.PropertyName}: {error?.ErrorMessage}"
                ).Aggregate((current, next) => $"\n{current} \n {next} \n");
                //return new()
                //{
                //    ErrorMessage = validationResult.Errors.First().ErrorMessage,
                //};

                //throw new ValidationException($"{error.PropertyName}: {error.ErrorMessage}");
                throw new Exception(error);

            }

            try
            {

                CreateUserResponse response = await _userService.CreateAsync(new()
                {
                    Email = request.Email,
                    Name = request.Name,
                    LastName = request.LastName,
                    Country = request.Country,
                    Password = request.Password,
                });
                return new()
                {
                    Message = response.Message,
                    Succeeded = response.Succeeded,
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
