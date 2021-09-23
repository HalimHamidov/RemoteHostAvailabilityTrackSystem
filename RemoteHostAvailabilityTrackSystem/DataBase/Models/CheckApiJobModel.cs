using System;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    /// <summary>
    /// Модель для хранения информации вызова в БД.
    /// </summary>
    public class CheckApiJobModel
    {
        /// <summary>
        /// идентификатор службы.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Api - удаленный хост(адресов) которое проверяем.
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// идентификатор пользователя.
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Последняя дата запуска.
        /// </summary>
        public DateTime? LastRunDate { get; set; }
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
