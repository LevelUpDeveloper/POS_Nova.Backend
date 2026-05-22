using System.Net;
using System.Text.Json;
using POS_Nova.Api.Responses;
using POS_Nova.Application.Exceptions;

namespace POS_Nova.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            var response = new ErrorResponse
            {
                TraceId = context.TraceIdentifier
            };

            switch (exception)
            {
                case ValidationException validationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = validationException.Message;
                    response.Errors = validationException.Errors;
                    break;

                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = exception.Message;
                    break;

                case UnauthorizedException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Message = exception.Message;
                    break;

                case ForbiddenException:
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    response.Message = exception.Message;
                    break;

                case ConflictException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = exception.Message;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An unexpected error occurred.";
                    break;
            }

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = response.StatusCode;

            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}