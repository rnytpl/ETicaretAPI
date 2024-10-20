using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using MediatR;


namespace ETicaretAPI.Application.Features.Commands.AppUser.Createuser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
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
