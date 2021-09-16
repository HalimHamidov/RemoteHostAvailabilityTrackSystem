using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase
{
    public static class RegisterDataBases
    {
        public static void RegisterContext(this IServiceCollection servicesCollection, string connectionString)
        {
            servicesCollection.AddScoped<IAddJobRepository, AddJobRepository>();
            servicesCollection.AddScoped<IGetJobsRepository, GetJobsRepository>();
            servicesCollection.AddScoped<IAddResultCheckRepository, AddResultCheckRepository>();
            servicesCollection.AddScoped<IGetCheckAllResultRepository, GetCheckAllResultRepository>();

            var dbContextBuilder = new DbContextOptionsBuilder();

            servicesCollection.AddDbContextPool<DataContext>(builder =>
            {
                builder.SetOptions(connectionString);
            });

            servicesCollection.AddSingleton(dbContextBuilder.SetOptions(connectionString).Options);

            servicesCollection.AddSingleton<Func<DataContext>>(s => () => new DataContext(s.GetRequiredService<DbContextOptions>()));
        }
    }
}