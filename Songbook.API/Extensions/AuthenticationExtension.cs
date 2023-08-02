using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Songbook.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = configuration["Jwt:Firebase:ValidIssuer"];
                opt.Audience = configuration["Jwt:Firebase:ValidAudience"];
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Firebase:ValidIssuer"],
                    ValidAudience = configuration["Jwt:Firebase:ValidAudience"]
                };
            });
            return services;
        }
    }
}
