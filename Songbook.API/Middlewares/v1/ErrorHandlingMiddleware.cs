using System;
using System.Net;
using Songbook.Domain.Exceptions.v1.Common;

namespace Songbook.API.Middlewares.v1
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ApiExceptions finalException = ex switch
            {
                GenericApiException exc => BindApiException(exc.Errors, exc.Message, exc.Code, (HttpStatusCode)exc.Code),
                _ => BindApiException(new List<string> { ex.Message }, ex.Message, 500, HttpStatusCode.InternalServerError)
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)finalException.HttpStatusCode;
            return context.Response.WriteAsync(finalException.ApiError.ToString());
        }

        private static ApiExceptions BindApiException(List<string> errors, string message, int code, HttpStatusCode statusCode)
        {
            return new ApiExceptions
            {
                HttpStatusCode = statusCode,
                ApiError = new ApiErrors
                {
                    Error = new ApiErrorsDetail(code, errors, message)
                }
            };
        }
    }
}

