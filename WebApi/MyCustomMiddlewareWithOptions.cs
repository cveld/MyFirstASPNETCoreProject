using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class MyCustomMiddlewareWithOptions
    {
        private readonly RequestDelegate _next;
        private readonly MyCustomMiddlewareOptions _options;

        public MyCustomMiddlewareWithOptions(RequestDelegate next, IOptions<MyCustomMiddlewareOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_options.DisplayBefore)
            {
                await context.Response.WriteAsync("------- Before ------ \n\r");
            }

            await _next(context);

            if (_options.DisplayAfter)
            {
                await context.Response.WriteAsync("\n\r------- After ------");
            }
        }
    }
}
