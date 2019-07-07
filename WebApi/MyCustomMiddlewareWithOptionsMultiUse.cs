using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class MyCustomMiddlewareWithOptionsMultiUse
    {
        private readonly RequestDelegate _next;
        private readonly MyCustomMiddlewareOptions _options;

        public MyCustomMiddlewareWithOptionsMultiUse(RequestDelegate next, MyCustomMiddlewareOptions options)
        {
            _next = next;
            _options = options;
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
