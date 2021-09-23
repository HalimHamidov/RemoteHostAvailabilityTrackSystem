using System;

namespace RemoteHostAvailabilityTrackSystem.Requests
{
    /// <summary>
    ///  запрос для получения результата в промежуток времени.
    /// </summary>
    public class GetCheckInPeriodRequest
    {
        /// <summary>
        /// проверяемая дата начиная с...
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// проверяемая дата по...
        /// </summary>
        public DateTime? DateEnd { get; set; }
    }
}
