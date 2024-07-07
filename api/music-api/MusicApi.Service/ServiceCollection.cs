﻿using Microsoft.Extensions.DependencyInjection;
using MusicApi.Helper.Helpers;
using MusicApi.Service.Services.AlbumService;
using MusicApi.Service.Services.ArtistService;
using MusicApi.Service.Services.AuthService;
using MusicApi.Service.Services.PlayListService;
using MusicApi.Service.Services.SongService;


namespace MusicApi.Service
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddMusicService(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IPlayListService, PlayListService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<FileHelper>();
            return services;
        }
    }
}
