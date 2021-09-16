using System;

namespace RemoteHostAvailabilityTrackSystem.Requests
{
    public class GetCheckInPeriodRequest
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}