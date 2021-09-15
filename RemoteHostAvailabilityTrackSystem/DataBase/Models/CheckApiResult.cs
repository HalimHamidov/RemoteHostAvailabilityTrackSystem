namespace RemoteHostAvailabilityTrackSystem.DataBase.Models
{
    public class CheckApiResult
    {
        public int Id { get; set; }
        public int CheckApiJobId { get; set; }
        public bool IsValid  { get; set; }
    }
}