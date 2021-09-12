using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    public class ExceptionMiddleware
    {
        private RequestDelegate Next { get; }
        private IHostEnvironment Environment {get;}

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var body = context.Response.Body;
            try
            {
                await Next(context);
            }
            catch (Exception e)
            {
                context.Response.Body = body;
                await HandleExceptionAsync(context, e);
            }
        }

        async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var statusCode = 500;
            context.Response.ContentType = "applicaton/json";
            context.Response.StatusCode = statusCode;

            if (e is KeyNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}