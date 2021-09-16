using System;
using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection collection)
        {
            collection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwagConstants.Swagger.Version, new OpenApiInfo
                {
                    Title = SwagConstants.Swagger.ApiName, Version = SwagConstants.Swagger.Version

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });
            return collection;
        }
    }
}