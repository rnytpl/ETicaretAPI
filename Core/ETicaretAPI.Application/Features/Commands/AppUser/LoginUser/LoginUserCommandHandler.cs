using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

using AppUserType = ETicaretAPI.Domain.Entities.Identity.AppUser;
namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<AppUserType> _userManager;
        readonly SignInManager<AppUserType> _signInManager;

        public LoginUserCommandHandler(UserManager<AppUserType> userManager, SignInManager<AppUserType> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUserType user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new UserNotFoundException("Incorrect email or password");


            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded) { 
                // Authorization is configured here
            }; 

            return new();
        }
    }
}