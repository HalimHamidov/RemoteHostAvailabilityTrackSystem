using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RemoteHostAvailabilityTrackSystem.DataBase
{
    [ExcludeFromCodeCoverage]
    public static class DbContextBuilderExtensions
    {
#if DEBUG
        private static ILoggerFactory _loggerFactory;
#endif
        public static DbContextOptionsBuilder SetOptions(this DbContextOptionsBuilder optionsBuilder,
            string connectionString)
        {
#if DEBUG
            _loggerFactory = LoggerFactory.Create(p => p.AddConsole());
#endif


            optionsBuilder.UseSqlite(connectionString)
#if DEBUG
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging();
#endif


            return optionsBuilder;
        }
    }
}