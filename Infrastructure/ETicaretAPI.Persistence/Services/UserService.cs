using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
using ETicaretAPI.Domain.Entities.Identity;
using FluentValidation;
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

                throw new Exception(error.Description);
            }
            else if (result.Succeeded)
            {
                response.Succeeded = result.Succeeded;
                response.Message = "New user created successfully";
            }

            return response;

        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenData)
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
