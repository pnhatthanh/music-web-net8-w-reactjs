using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_api.Caches.RedisCaching
{

    public class RedisService : IRedisService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connection;
        public RedisService(IDistributedCache distributedCache, IConnectionMultiplexer connection)
        {
            _distributedCache = distributedCache;
            _connection = connection;
        }

        public async Task<string?> GetCacheAsync(string key)
        {
            var data = await _distributedCache.GetStringAsync(key);
            return string.IsNullOrEmpty(data) ? null : data;
        }

        public async Task SetCacheAsync(string key, object data, TimeSpan timeOut)
        {
            if (data == null)
                return;
            var serializerData = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await _distributedCache.SetStringAsync(key, serializerData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeOut,
            });
        }
        public async Task RemoveCacheAsync(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Value cannot null in cache");
            var server=_connection.GetServer(_connection.GetEndPoints().First());  
            foreach(var key in server.Keys(pattern: pattern))
            {
                await _distributedCache.RemoveAsync(key!); 
            }
        }
    }
}
