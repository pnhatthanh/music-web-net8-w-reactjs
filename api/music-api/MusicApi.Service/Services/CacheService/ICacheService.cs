using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.CacheService
{
    public interface ICacheService
    {
        public Task<string?> GetCacheAsync(string key);
        public Task SetCacheAsync(string key, object data, TimeSpan timeOut);
        public Task RemoveCacheAsync(string pattern);
    }
}
