using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using music_api.Caches.RedisCaching;
using System;
using System.Text;
namespace music_api.Caches
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLive;
        public CacheAttribute(int timeToLive)
        {
            _timeToLive = timeToLive;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var cacheService = context.HttpContext.RequestServices.GetService<IRedisService>();
            if (!configuration.GetValue<bool>("RedisConfiguration:Enabled"))
            {
                await next();
                return;
            }
            var key = GenerateKey(context.HttpContext.Request);
            string data = await cacheService.GetCacheAsync(key);
            if (string.IsNullOrEmpty(data))
            {
                var excutedResult = await next();
                if (excutedResult.Result is OkObjectResult okObject)
                    await cacheService.SetCacheAsync(key, okObject.Value, TimeSpan.FromSeconds(_timeToLive));
                return;
            }
            var result = new ContentResult
            {
                Content = data,
                ContentType = "application/json",
                StatusCode = 200
            };
            context.Result = result;
            return;
        }
        private static string GenerateKey(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(q => q.Key))
            {
                keyBuilder.Append($"-{key}_{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
