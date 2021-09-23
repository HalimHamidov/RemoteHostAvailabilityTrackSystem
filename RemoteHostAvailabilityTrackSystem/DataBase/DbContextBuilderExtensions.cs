using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RemoteHostAvailabilityTrackSystem.DataBase
{
    /// <summary>
    /// Расширение для настроек контекста.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DbContextBuilderExtensions
    {
        private static ILoggerFactory _loggerFactory;
        /// <summary>
        /// установка настройки.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder SetOptions(this DbContextOptionsBuilder optionsBuilder,
            string connectionString)
        {
            _loggerFactory = LoggerFactory.Create(p => p.AddConsole());


            optionsBuilder.UseSqlite(connectionString)
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging();

            return optionsBuilder;
        }
    }
}
