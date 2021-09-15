using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RemoteHostAvailabilityTrackSystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            try{
                new WebHostBuilder().UseStartup<Startup>().UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Loopback, 8080);//HTTP port
                    })
                    .Build()
                    .Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}