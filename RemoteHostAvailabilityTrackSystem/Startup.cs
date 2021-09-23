using System;
using AutoMapper;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RemoteHostAvailabilityTrackSystem.DataBase;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories;
using RemoteHostAvailabilityTrackSystem.Jobs;
using RemoteHostAvailabilityTrackSystem.MiddleWares;
using RemoteHostAvailabilityTrackSystem.Services;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem
{
    /// <summary>
    /// класс регистрации
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// конфигурация
        /// </summary>
        public static IConfiguration Configuration { get; private set; }
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="configuration"></param>
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
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>

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
            services.AddScoped<ICheckAllApiService, CheckAllApiService>();
            services.AddScoped<IGetCheckInPeriodService, GetCheckInPeriodService>();
            services.AddScoped<ICheckAuthService, CheckAuthService>();
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<JobFactory>();
            services.AddScoped<CheckApiJob>();

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
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
