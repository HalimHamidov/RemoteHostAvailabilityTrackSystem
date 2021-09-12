using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;

namespace RemoteHostAvailabilityTrackSystem.MiddleWares
{
    public static class MiddleWareConfig
    {
        public static IApplicationBuilder UseSwaggerWithOptions(this IApplicationBuilder builder)
        {
            builder.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                {
                    if (!httpRequest.Headers.ContainsKey("X-Forwarders-Host")) return;
                        
                    var serverUrl = $"{httpRequest.Headers["X-Forwarded-Proto"]}://" +
                                    $"{httpRequest.Headers["X-Forwarded-Host"]}" +
                                    $"{httpRequest.Headers["X-Forwarded-Prefix"]}";

                    swaggerDoc.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer {Url = serverUrl}
                    };
                });
            });
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwagConstants.Swagger.EndPoint, SwagConstants.Swagger.ApiName);
            });
            return builder;
        }
    }
}