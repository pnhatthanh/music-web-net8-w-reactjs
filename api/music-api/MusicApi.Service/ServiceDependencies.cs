using Microsoft.Extensions.DependencyInjection;
using MusicApi.Infracstructure.Services.AlbumService;
using MusicApi.Infracstructure.Services.ArtistService;
using MusicApi.Infracstructure.Services.AuthService;
using MusicApi.Infracstructure.Services.CacheService;
using MusicApi.Infracstructure.Services.PlayListService;
using MusicApi.Infracstructure.Services.SongService;
using MusicApi.Infracstructure.Services.UserService;


namespace MusicApi.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddMusicService(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IPlayListService, PlayListService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ICacheService, CacheService>();
            return services;
        }
    }
}
