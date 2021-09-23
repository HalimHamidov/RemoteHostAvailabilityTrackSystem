using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    /// <summary>
    ///  Расширение для исключений
    /// </summary>
    public class ExceptionMiddleware
    {
        private RequestDelegate Next { get; }
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
        }
        /// <summary>
        /// вызываемый метод при исключении
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
            var response = new {error = e.Message};
            await context.Response.WriteAsJsonAsync(response);

            if (e is KeyNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}
