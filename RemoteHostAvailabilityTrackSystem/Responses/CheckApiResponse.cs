using Newtonsoft.Json;

namespace RemoteHostAvailabilityTrackSystem.Responses
{
    /// <summary>
    /// Ответ сервиса о доступности сайта.
    /// </summary>
    public class CheckApiResponse
    {
        /// <summary>
        /// флаг доступности.
        /// </summary>
        public bool IsValid { get; set; }
    }
}
