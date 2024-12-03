using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
using ETicaretAPI.Application.Helpers;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {

        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> CreateAsync(CreateUser model)
        {

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = $"{model.Name}{model.LastName}",
                Email = model.Email,
                NameSurname = $"{model.Name} {model.LastName}",
            }, model.Password);

            CreateUserCommandResponse response = new CreateUserCommandResponse();


            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();

                throw new Exception(error?.Description);
            }
            else if (result.Succeeded)
            {
                response.Succeeded = result.Succeeded;
                response.Message = "New user created successfully";
            }

            return response;

        }

        public async Task<bool> UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                resetToken = resetToken.UrlDecode();

                bool isPasswordSame = await _userManager.CheckPasswordAsync(user, newPassword);
                if (isPasswordSame)
                    throw new Exception("Choose a password different from your previous passwords.");

                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    
                } else
                {
                    throw new Exception("An unexpected error occurred");
                }
            }

            return true;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenData)
        {

            if (user != null )
            {
                user.RefreshToken = refreshToken;

                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenData);

                IdentityResult result = await _userManager.UpdateAsync(user);


            } else
            {
                throw new UserNotFoundException("User does not exist");

            }


        }
    }
}
