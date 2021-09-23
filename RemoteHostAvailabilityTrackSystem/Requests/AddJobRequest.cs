namespace RemoteHostAvailabilityTrackSystem.Requests
{
    /// <summary>
    /// запрос для добавления новой службы.
    /// </summary>
    public class AddJobRequest
    {
        /// <summary>
        /// сайт которое проверяем.
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// интервал в часах.
        /// </summary>
        public int? HoursInterval { get; set; }
        /// <summary>
        /// интервал в минутах.
        /// </summary>
        public int? MinutesInterval { get; set; }
    }
}
