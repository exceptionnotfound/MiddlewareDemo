using Microsoft.AspNet.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHeaderMiddleware>();
        }
    }
}
