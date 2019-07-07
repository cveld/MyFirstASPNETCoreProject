using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Extensions
{
    public static class MyCustomMiddlewareWithOptionsMultiUseExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddlewareWithOptionsMultiUse(this IApplicationBuilder builder, MyCustomMiddlewareOptions options = default)
        {
            options = options ?? new MyCustomMiddlewareOptions();
            return builder.UseMiddleware<MyCustomMiddlewareWithOptionsMultiUse>(options);
        }
    }
}
