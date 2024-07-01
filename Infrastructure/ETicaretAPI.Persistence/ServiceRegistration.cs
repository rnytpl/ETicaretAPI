using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            //services.AddScoped<IValidator<VM_Create_Product>, CreateProductValidator>();
        }
    }
}
