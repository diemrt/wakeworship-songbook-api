using System;
using Songbook.API.Middlewares.v1;

namespace Songbook.API.Extensions
{
    public static class ErrorMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}

