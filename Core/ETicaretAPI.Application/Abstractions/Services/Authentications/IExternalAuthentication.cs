﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task FacebookLoginASync();
        Task GoogleLoginAsync();
        Task XLoginAsync();
    }
}
