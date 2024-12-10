using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Helpers;
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
        readonly IMailService _mailService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _mailService = mailService;
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
            AppUser? user = await _userManager.FindByEmailAsync(Email);

            if (user == null) throw new UserNotFoundException("Incorrect email or password");


            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 60);
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
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 60);

                return token;
            } else
            {
                throw new UserNotFoundException("User was not found");
            }
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                resetToken = resetToken.UrlEncode();

                await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
            }
        }

        public async Task<bool> VerifyResetTokenAsync(string userId, string resetToken)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {

                resetToken = resetToken.UrlDecode();


                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }

            return false;
        }
    }
}
