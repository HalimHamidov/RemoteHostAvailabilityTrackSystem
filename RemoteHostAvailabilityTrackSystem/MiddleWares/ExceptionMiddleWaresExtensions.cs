using Microsoft.AspNetCore.Builder;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    public static class ExceptionMiddleWaresExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerEx(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}