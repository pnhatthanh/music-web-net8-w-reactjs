using Microsoft.Extensions.DependencyInjection;
using MusicApi.Helper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Helper
{
    public static class HelperDependencies
    {
        public static IServiceCollection AddHelperService(this IServiceCollection services)
        {
            services.AddScoped<FileHelper>();
            services.AddScoped<JwtTokenHelper>();
            return services;
        }
    }
}
