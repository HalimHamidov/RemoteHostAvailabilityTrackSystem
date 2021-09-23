using System;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    /// <summary>
    /// Результат проверки.
    /// </summary>
    public class CheckApiResult
    {
        /// <summary>
        /// идентификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// идентификатор службы.
        /// </summary>
        public int CheckApiJobId { get; set; }
        /// <summary>
        /// Результат проверки.
        /// </summary>
        public bool IsValid  { get; set; }
        /// <summary>
        /// дата запуска.
        /// </summary>
        public DateTime? RunDate { get; set; }
    }
}
