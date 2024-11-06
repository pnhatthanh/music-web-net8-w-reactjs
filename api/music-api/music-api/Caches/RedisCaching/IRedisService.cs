using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_api.Caches.RedisCaching
{
    public interface IRedisService
    {
        public Task<string?> GetCacheAsync(string key);
        public Task SetCacheAsync(string key, object data, TimeSpan timeOut);
        public Task RemoveCacheAsync(string pattern);
    }
}
