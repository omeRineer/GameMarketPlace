using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middlewares.ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ExceptionHandle(context, exception);
            }
        }

        private Task ExceptionHandle(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "Internal server error";

            var exceptionDetail = GetDetail(exception).ToJson();
            return context.Response.WriteAsync(exceptionDetail);
        }

        private ExceptionDetail GetDetail(Exception exception)
        {
            string exceptionType = exception.GetType().Name;
            switch (exception)
            {
                case ValidationException validationException:
                    return new ValidationExceptionDetail
                    {
                        Type = exceptionType,
                        Message = exception.Message,
                        Errors = validationException.Errors
                    };

                default:
                    return new ExceptionDetail
                    {
                        Type = exceptionType,
                        Message = exception.Message
                    };
            }
        }
    }
}
