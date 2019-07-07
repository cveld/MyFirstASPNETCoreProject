using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Extensions
{
    public static class MyCustomMiddlewareWithOptionsExtensions
    {
        public static IServiceCollection AddMyCustomMiddlewareWithOptions(this IServiceCollection service, Action<MyCustomMiddlewareOptions> options = default)
        {
            options = options ?? (opts => { });

            service.Configure(options);
            return service;
        }

        public static IApplicationBuilder UseMyCustomMiddlewareWithOptions(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseMiddleware<MyCustomMiddlewareWithOptions>();
        }
    }
}
