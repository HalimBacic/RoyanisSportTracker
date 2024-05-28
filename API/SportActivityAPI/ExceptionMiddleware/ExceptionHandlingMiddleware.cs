using SportActivityAPI.Share.Exceptions;
using System.Net;
using System.Text.Json;

namespace SportActivityAPI.ExceptionMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            ErrorInformation errorResponse = new ErrorInformation();
            errorResponse.Message = exception.Message;
            errorResponse.StackTrace = exception.StackTrace;
            switch (exception)
            {
                case UnauthorizedException ex:
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorResponse.StatusCode = response.StatusCode;
                    break;
                case IncopatibleDatabaseException ex:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.StatusCode = response.StatusCode;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error!";
                    break;
            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
