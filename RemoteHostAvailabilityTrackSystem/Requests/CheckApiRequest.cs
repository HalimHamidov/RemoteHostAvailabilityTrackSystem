using Newtonsoft.Json;

namespace RemoteHostAvailabilityTrackSystem.Requests
{
    /// <summary>
    ///  запрос для проверки доступности сайта.
    /// </summary>
    public class CheckApiRequest
    {
        /// <summary>
        /// удаленный хост(сайт).
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// идентификатор службы.
        /// </summary>
        [JsonIgnore]
        public int? JobId { get; set; }
    }
}
