using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class SimpleCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HashSet<string> _urlList;
        private ConcurrentDictionary<string, CacheItem> cache = new ConcurrentDictionary<string, CacheItem>();

        public SimpleCacheMiddleware(RequestDelegate next, IOptions<SimpleCacheMiddlewareOptions> options)
        {
            _next = next;
            _urlList = options.Value.UrlList;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cachekey = context.Request.Path;
            var datetimenow = DateTime.Now;
            if (cache.ContainsKey(cachekey))
            {
                if (cache[cachekey].Timestamp > datetimenow)
                {
                    await context.Response.WriteAsync(cache[context.Request.Path].Content);
                    return;
                }
            }
            
            if (!_urlList.Contains(cachekey))
            {
                // regular http pipeline
                await _next(context);
            }
            else
            {
                // caching http pipeline
                // overgenomen van https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
                
                //Copy a pointer to the original response body stream
                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    //...and use that for the temporary response body
                    context.Response.Body = responseBody;

                    //Continue down the Middleware pipeline, eventually returning to this class
                    await _next(context);

                    //We need to read the response stream from the beginning...
                    context.Response.Body.Seek(0, SeekOrigin.Begin);

                    //...and copy it into a string
                    string text = await new StreamReader(context.Response.Body).ReadToEndAsync();

                    var cacheitem = new CacheItem
                    {
                        Timestamp = datetimenow.AddSeconds(30), // keep stuff 30 seconds in cache
                        Content = text
                    };
                    cache.AddOrUpdate(cachekey, cacheitem, (key, item) => cacheitem);

                    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                    await responseBody.CopyToAsync(originalBodyStream);
                }                                              
            }
        }
    }
}
