﻿using ETicaretAPI.Application.Abstractions.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application
{
    public static  class ServiceRegistration
    {
        public static void AddApplicationServices (this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())); 
        }     
       
    }
}
