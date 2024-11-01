using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60);
                return token;

            };

            throw new AuthenticationErrorException("Authentication failed");

        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(user => user.RefreshToken == refreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(60, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60);

                return token;
            } else
            {
                throw new UserNotFoundException("User was not found");
            }
        }
    }
}
