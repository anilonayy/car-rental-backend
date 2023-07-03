using Core.Utilities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                var exceptionFeature = new ExceptionHandlerFeature
                {
                    Error = e,
                    Path = httpContext.Request.Path
                };

                httpContext.Features.Set<IExceptionHandlerFeature>(exceptionFeature);

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {

            Console.WriteLine(e);

            httpContext.Response.ContentType = "application/json";
            var exceptionFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            string message = "Internal Server Error";
            string titleMessage = "Error!";


            // Get Error's status code.
            var statusCode = exceptionFeature.Error switch
            {
                ClientSideException => 400,
                ValidationException => 400,
                ConflictException => 409,
                NotFoundException => 400,
                _ => 500
            };

            httpContext.Response.StatusCode = statusCode;




            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    status = statusCode,
                    message = message,
                    errors = ((ValidationException)e).Errors
                }.ToJson());
            }

            else if(
                e.GetType() == typeof(NotFoundException) ||
                e.GetType() == typeof(ClientSideException)
                )
            {
                message = e.Message;
            }
            

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                title = titleMessage,
                status = statusCode,
                message = message
            }.ToJson());


        }
    }
}