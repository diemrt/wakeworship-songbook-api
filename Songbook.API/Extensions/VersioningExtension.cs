using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Songbook.API.Extensions
{
    public static class VersioningExtension
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = false;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;

                // DEFAULT Version reader is QueryStringApiVersionReader();  
                // clients request the specific version using the api-version header
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            return services;
        }
    }
}

