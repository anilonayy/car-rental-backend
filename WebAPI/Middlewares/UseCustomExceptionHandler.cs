using Core.Utilities.Exceptions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Business.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;


                    var response = new ErrorResult<object>(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
