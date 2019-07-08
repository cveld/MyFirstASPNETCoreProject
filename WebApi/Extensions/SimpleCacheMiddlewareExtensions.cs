using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Extensions
{
    public static class SimpleCacheMiddlewareExtensions
    {
        public static IServiceCollection AddSimpleCacheMiddleware(this IServiceCollection service, Action<SimpleCacheMiddlewareOptions> options = default)
        {            
            service.Configure(options);
            return service;
        }


        public static IApplicationBuilder UseSimpleCacheMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleCacheMiddleware>();
        }
    }
}
