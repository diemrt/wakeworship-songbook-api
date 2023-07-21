using System;
namespace Songbook.API.Extensions
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddV1RServices();

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddV1Repositories();

        private static IServiceCollection AddV1RServices(this IServiceCollection services) => services
            .AddTransient<Domain.Services.v1.ISongService, Infrastructure.Services.v1.SongService>()
            ;

        private static IServiceCollection AddV1Repositories(this IServiceCollection services) => services
            .AddTransient<Domain.Repositories.v1.IChordTypeRepository, Infrastructure.Repositories.v1.ChordTypeRepository>()
            .AddTransient<Domain.Repositories.v1.ISongBlockTypeRepository, Infrastructure.Repositories.v1.SongBlockTypeRepository>()
            .AddTransient<Domain.Repositories.v1.ISongRepository, Infrastructure.Repositories.v1.SongRepository>()
            .AddTransient<Domain.Repositories.v1.ISongBlockRepository, Infrastructure.Repositories.v1.SongBlockRepository>()
            .AddTransient<Domain.Repositories.v1.ISongRowRepository, Infrastructure.Repositories.v1.SongRowRepository>()
            .AddTransient<Domain.Repositories.v1.IPhraseChordRepository, Infrastructure.Repositories.v1.PhraseChordRepository>()
            ;
    }
}

