using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountApi.Common;
using AccountApi.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AccountApi.Web
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContextCreationMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextCreationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers.ToDictionary(a => a.Key, a => a.Value.ToString());
            var context = new CallContext(headers);

            using (new ContextScope(context))
            {
                await _next(httpContext);
            }               
        }
        private static bool TryGetHeaderValue(IHeaderDictionary headers, string headerName, bool isMandatory, out string headerValue)
        {
            headerValue = null;
            if (headers.TryGetValue(headerName, out StringValues values) && string.IsNullOrWhiteSpace(values) == false)
                return true;
            else if (isMandatory)
                headerValue = values;
            return false;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContextCreationMiddlewareExtensions
    {
        public static IApplicationBuilder UseContextCreationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextCreationMiddleware>();
        }
    }
}
