using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RemoteHostAvailabilityTrackSystem.Jobs;

namespace RemoteHostAvailabilityTrackSystem
{
    /// <summary>
    /// Точка входа для нашей программы.
    /// </summary>
    public class Program
    {
         /// <summary>
         /// entry point
         /// </summary>
         /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder().UseStartup<Startup>().UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Loopback, 8080); //HTTP port
                    })
                    .Build();

                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    DataScheduler.Start(serviceProvider);
                }
                host.Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
