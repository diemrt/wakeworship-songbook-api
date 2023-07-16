using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Infrastructure;

namespace Songbook.API.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, string environment)
        {
            var connectionString = configuration.GetSection(environment).GetConnectionString("SongbookDb");
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContextPool<SongbookContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(
                        connectionString,
                        serverOptions =>
                        {
                            serverOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
                        }
                    );
                });

            return services;
        }
    }
}

