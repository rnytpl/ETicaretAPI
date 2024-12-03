using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        readonly IAuthService _authService;
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
            {
                throw new Exception("Passwords do not match");
            }

            var response = await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);

            return new() { Result = response};
        }
    }
}
