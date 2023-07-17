using System;
namespace Songbook.API.Extensions
{
	public static class CorsExtension
	{
        public static IServiceCollection AddCorsExtension(this IServiceCollection service)
        {
            return service.AddCors(options =>
            {
                options.AddPolicy("Default", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://192.168.56.1:3000", "http://127.0.0.1:3000").AllowAnyHeader().AllowAnyMethod().Build();
                });

            });
        }
    }
}

