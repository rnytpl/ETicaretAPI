using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ETicaretAPI.Infrastructure.GobalErrorHandler
{
    public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            string errorMessage = exception?.Message;
            logger.LogError(exception, errorMessage);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = "Server Error",
                Status = httpContext.Response.StatusCode,
                Message = errorMessage
            });

            return true;
        }
    }
}
