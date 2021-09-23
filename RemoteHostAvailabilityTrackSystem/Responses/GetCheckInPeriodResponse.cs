using System;

namespace RemoteHostAvailabilityTrackSystem.Responses
{
    /// <summary>
    /// Ответ получения всех проверок в периоде.
    /// </summary>
    public class GetCheckInPeriodResponse
    {
        /// <summary>
        /// Сайт
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// флаг валидности.
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// дата.
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
