using System;

namespace RemoteHostAvailabilityTrackSystem.Responses
{
    public class GetCheckInPeriodResponse
    {
        public string Api { get; set; }
        public bool IsValid { get; set; }
        public DateTime? Date { get; set; }
    }
}