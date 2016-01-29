using Microsoft.AspNet.Builder;
using MiddlewareDemo.Middleware;
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

        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }

        public static IApplicationBuilder UseProcessingTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProcessingTimeMiddleware>();
        }
    }
}
