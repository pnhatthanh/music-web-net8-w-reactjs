using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.CacheService
{
    
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<string?> GetCacheAsync(string key)
        {
            var data=await _distributedCache.GetStringAsync(key);
            return string.IsNullOrEmpty(data) ? null : data;
        }

        public async Task SetCacheAsync(string key, object data, TimeSpan timeOut)
        {
            if (data == null)
                return;
            var serializerData = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }) ;
            await _distributedCache.SetStringAsync(key, serializerData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow= timeOut,
            });
        }
        public Task RemoveCacheAsync(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
