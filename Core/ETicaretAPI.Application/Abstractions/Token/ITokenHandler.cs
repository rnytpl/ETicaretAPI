﻿using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute, AppUser appUser);
        string CreateRefreshToken();

    }
}
