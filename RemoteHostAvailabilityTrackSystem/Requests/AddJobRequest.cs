namespace RemoteHostAvailabilityTrackSystem.Requests
{
    public class AddJobRequest
    {
        public string Api { get; set; }
        public int? HoursInterval { get; set; }
        public int? MinutesInterval { get; set; }
    }
}