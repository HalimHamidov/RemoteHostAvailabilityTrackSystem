using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CheckApiJobModel> CheckApiJobModels { get; set; }
        public DbSet<CheckApiResult> CheckApiResults { get; set; }
        
    }
}