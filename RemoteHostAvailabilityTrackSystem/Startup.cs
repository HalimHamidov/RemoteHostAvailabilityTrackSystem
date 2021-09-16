using System;
using AutoMapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RemoteHostAvailabilityTrackSystem.DataBase;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.MiddleWares;
using RemoteHostAvailabilityTrackSystem.Services;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                return settings;
            };
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors()
                .AddMvcCore()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
                .AddApiExplorer()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddAutoMapper(typeof(Startup))
                .AddSwagger();

            services.RegisterContext("Datasource = local.db");
            
            services
                .AddRouting()
                .AddControllers();
            
            services
                .AddHealthChecks();
            services.AddAutoMapper((Action<IServiceProvider, IMapperConfigurationExpression>) null,
                AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<ICheckApiService, CheckApiService>();
            services.AddScoped<IAddJobService, AddJobService>();
            services.AddScoped<IGetJobsService, GetJobsService>();
            services.AddScoped<IGetCheckInPeriodService, GetCheckInPeriodService>();
            services.AddScoped<ICheckAllApiService, CheckAllApiService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandlerEx();
            app.UseRouting();
            app.UseAuthentication();
            
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwaggerWithOptions();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
            });

            if (File.Exists("local.db"))
            {
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
                var context = serviceScope?.ServiceProvider.GetService<Func<DataContext>>();
                context?.Invoke().Database.EnsureCreated();
            }
            Console.WriteLine("Server started");
        }
    }
}