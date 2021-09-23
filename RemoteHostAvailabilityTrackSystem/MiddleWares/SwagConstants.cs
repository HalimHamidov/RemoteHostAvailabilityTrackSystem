namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    /// <summary>
    /// константы для сваггера
    /// </summary>
    public class SwagConstants
    {
        /// <summary>
        /// сваггер
        /// </summary>
        public static class Swagger
        {
            /// <summary>
            /// конечная точка.
            /// </summary>
            public static string EndPoint => $"../swagger/{Version}/swagger.json";
            /// <summary>
            /// наименование API
            /// </summary>
            public static string ApiName => "URL_API";
            /// <summary>
            /// версия.
            /// </summary>
            public static string Version => "v1";
        }
    }
}
