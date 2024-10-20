using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public Task FacebookLoginASync()
        {
            throw new NotImplementedException();
        }

        public Task GoogleLoginAsync()
        {
            throw new NotImplementedException();
        }
        public Task XLoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Token> LoginAsync(string Email, string Password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByEmailAsync(Email);
            if (user == null) throw new UserNotFoundException("Incorrect email or password");


            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);


                return token;

            };

            throw new AuthenticationErrorException("Authentication failed");

        }
    }
}
