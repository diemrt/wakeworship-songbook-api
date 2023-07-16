﻿using System;
namespace Songbook.API.Extensions
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddV1Services()
            ;

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddV1Repositories();

        private static IServiceCollection AddV1Services(this IServiceCollection services) => services
            ;

        private static IServiceCollection AddV1Repositories(this IServiceCollection services) => services
            .AddTransient<Domain.Repositories.v1.IChordTypeRepository, Infrastructure.Repositories.v1.ChordTypeRepository>()
            .AddTransient<Domain.Repositories.v1.ISongBlockTypeRepository, Infrastructure.Repositories.v1.SongBlockTypeRepository>()
            ;
    }
}

