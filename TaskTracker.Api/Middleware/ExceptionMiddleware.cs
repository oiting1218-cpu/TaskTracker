using TaskTracker.Api.Exceptions;

namespace TaskTracker.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) //Note: framework calls this method automatically as part of HTTP request pipeline
        {
            try
            {
                await _next(context); //pass request forward
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occured.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode;
            if (exception is EmailAlreadyExistsException)
                statusCode = StatusCodes.Status409Conflict; //status code 409 - Resource conflict (Duplicate email)            
            else if (exception is InvalidCredentialsException)
                statusCode = StatusCodes.Status401Unauthorized; //status code 401 - Login credentials (username/password) are wrong, access token is expired, invalid or missing, user is not logged in
            else
                statusCode = StatusCodes.Status500InternalServerError;
            context.Response.StatusCode = statusCode;
            var response = new
            {
                status = statusCode,
                message = exception.Message
            };
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
