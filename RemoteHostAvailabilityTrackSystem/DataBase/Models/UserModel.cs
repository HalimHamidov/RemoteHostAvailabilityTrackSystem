using System;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public DateTime? FinishKeyDate { get; set; }
    }
}
