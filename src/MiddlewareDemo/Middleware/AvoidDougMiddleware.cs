using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware
{
    public class AvoidDougMiddleware
    {
        private readonly RequestDelegate _next;

        public AvoidDougMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Request.Headers.Contains(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("X-Asker", "Doug")))
            {
                context.Response.Headers.Add("X-Question-Response", "Go ask Mary!");
                return;
            }
        }
    }
}
