using DFO_aspnetcore_api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DFO_aspnetcore_api.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}