using Microsoft.AspNetCore.Builder;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    /// <summary>
    /// Расширения MiddleWare исключений
    /// </summary>
    public static class ExceptionMiddleWaresExtensions
    {
        /// <summary>
        /// Регистрация Расширения MiddleWare исключений 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionHandlerEx(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
