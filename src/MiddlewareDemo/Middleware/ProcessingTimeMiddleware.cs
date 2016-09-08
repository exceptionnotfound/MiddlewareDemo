using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware
{
    public class ProcessingTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ProcessingTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();

            await _next(context);

            context.Response.Headers.Add("X-Processing-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
        }
    }
}
