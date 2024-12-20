﻿using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Features.Commands.AppUser.Createuser;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenData);
        Task<bool> UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}
