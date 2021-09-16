using System;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    public class CheckApiJobModel
    {
        public int Id { get; set; }
        
        public int? UserId { get; set; }
        
        public string Api { get; set; }
        
        public int? HoursInterval { get; set; }

        public int? MinutesInterval { get; set; }
        
        public DateTime? LastRunDate { get; set; }
    }
}