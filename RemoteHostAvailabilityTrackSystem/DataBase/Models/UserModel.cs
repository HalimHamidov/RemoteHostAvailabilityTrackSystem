using System;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    /// <summary>
    /// пользователь
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// логин.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Ключ для авторизации.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Срок действия ключа.
        /// </summary>
        public DateTime? FinishKeyDate { get; set; }
    }
}
