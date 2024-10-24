using ETicaretAPI.Application;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.GobalErrorHandler;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// ADDS SERVICES TO CONTAINER //

builder.Services.AddControllers();
//builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>());
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

builder.Services.AddInfraStructureService();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAuthentication(options =>

    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme
)
    .AddJwtBearer("Admin", options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = true, // ensures the token's audience matches the expected one
                ValidateIssuer = true, // verifies that the token's issuer is trusted and valid
                ValidateLifetime = true, //  ensures the token has not expired
                ValidateIssuerSigningKey = true, // confirms the token's signing key is valid
                ValidAudience = builder.Configuration["Token:Audience"],
                ValidIssuer = builder.Configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                LifetimeValidator = (notBefore, expires, SecurityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            };
        }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Defaults to wwwroot, serves files from wwwroot directory
app.UseStaticFiles();
app.UseCors();

app.UseHttpsRedirection();

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
