using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase
{   /// <summary>
    /// база данных.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// .ctor.
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// таблица модели служб.
        /// </summary>
        public DbSet<CheckApiJobModel> CheckApiJobModels { get; set; }
        /// <summary>
        /// таблица результата проверки.
        /// </summary>
        public DbSet<CheckApiResult> CheckApiResults { get; set; }
        /// <summary>
        /// таблица пользователей.
        /// </summary>
        public DbSet<UserModel> UserModels { get; set; }
    }
}
