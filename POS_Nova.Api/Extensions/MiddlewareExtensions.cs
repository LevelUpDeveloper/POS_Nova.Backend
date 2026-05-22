
namespace POS_Nova.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Middleware.ExceptionHandlingMiddleware>();
        }
    }
}
