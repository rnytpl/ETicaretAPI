using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {

        readonly UserManager<AppUser> _userManager;
        readonly IValidator<CreateUser> _validator;

        public UserService(UserManager<AppUser> userManager, IValidator<CreateUser> validator = null)
        {
            _userManager = userManager;
            _validator = validator;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            var validationResult = _validator.Validate(model);

            

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.First();

                // Throw an exception with all error messages
                throw new CreateUserException(errors.ToString());
            }

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = $"{model.Name}{model.LastName}",
                Email = model.Email,
                NameSurname = $"{model.Name} {model.LastName}",
            }, model.Password);

            CreateUserResponse response = new CreateUserResponse();


            if (result.Succeeded)
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
