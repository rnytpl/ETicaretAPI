
using ETicaretAPI.API.Configurations;
using ETicaretAPI.Application;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.GobalErrorHandler;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Persistence;
using ETicaretAPI.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using System.Security.Claims;
using System.Text; 

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ADDS SERVICES TO CONTAINER //

builder.Services.AddControllers();
//builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>());
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddSignalRServices();

builder.Services.AddInfraStructureService();
builder.Services.AddCors(
    options => 
        options.AddDefaultPolicy(policy => 
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
        ));

builder.Host.UseSerilog(new LoggerConfigurer(configuration).configureLogger());

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

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
                ValidAudience = configuration["Token:Audience"],
                ValidIssuer = configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                LifetimeValidator = (notBefore, expires, SecurityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                NameClaimType = ClaimTypes.Name, // Name claim holds the user's name identifier
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

app.UseSerilogRequestLogging();

app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseExceptionHandler();


app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;

    LogContext.PushProperty("user_name", userName);

    await next();
});

app.MapControllers();
app.MapHubs();

app.Run();
