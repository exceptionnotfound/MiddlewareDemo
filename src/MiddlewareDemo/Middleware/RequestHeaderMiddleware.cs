using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("X-Cancel-Request"))
            {
                context.Response.StatusCode = 500;
                return;
            }

            await _next.Invoke(context);

            if (context.Request.Headers.Keys.Contains("X-Transfer-By"))
            {
                context.Response.Headers.Add("X-Transfer-Success", "true");
            }
        }
    }
}
