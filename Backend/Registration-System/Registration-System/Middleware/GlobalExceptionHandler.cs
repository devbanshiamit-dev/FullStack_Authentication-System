using Microsoft.AspNetCore.Diagnostics;
using Registration_System.DTO;
using Registration_System.Exceptions;
using System.Net;

namespace Registration_System.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            switch (exception)
            {
                case EmailAlreadyExistsException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                case InvalidCredentialsException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case UserNotFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case TokenExpiredException: 
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case TokenNotFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case TokenRevokedException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var error = new ErrorResponse
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message,
                TimeStamp = DateTime.UtcNow
            };

            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);
            return true;
        }
    }
}
