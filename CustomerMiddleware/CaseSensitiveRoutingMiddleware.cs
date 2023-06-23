using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Web_Api.CustomerMiddleware;

public class CaseSensitiveRoutingMiddleware
{
    private readonly RequestDelegate _next;

    public CaseSensitiveRoutingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint != null)
        {
            var routePattern = (endpoint as RouteEndpoint)?.RoutePattern?.RawText;
            if (routePattern != null && !context.Request.Path.Value.EndsWith(routePattern, StringComparison.Ordinal))
            {
                context.Response.StatusCode = 404;
                return;
            }
        }

        await _next(context);
    }
}

