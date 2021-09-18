using Newtonsoft.Json;

namespace RemoteHostAvailabilityTrackSystem.Requests
{
    public class CheckApiRequest
    {
        public string Api { get; set; }
        [JsonIgnore]
        public int? JobId { get; set; }
    }
}
