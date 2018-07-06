using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Middlewares
{
    public class AlwaysHttpsMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly PathString[] _ignoredPathStrings;

        public AlwaysHttpsMiddleware(RequestDelegate next, List<string> ignoredStrings)
        {
            _next = next;
            _ignoredPathStrings = ignoredStrings.Select(x => new PathString(x)).ToArray();
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.IsHttps || _ignoredPathStrings.Any(context.Request.Path.StartsWithSegments))
            {
                await _next.Invoke(context);
            }
            else
            {
                var request = context.Request;
                if (!string.Equals(request.Method, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("This site requires HTTPS.");
                }
                else
                {
                    var newUrl = string.Concat(
                        "https://",
                        request.Host.ToUriComponent(),
                        request.PathBase.ToUriComponent(),
                        request.Path.ToUriComponent(),
                        request.QueryString.ToUriComponent());

                    context.Response.Redirect(newUrl);
                }
            }
        }
    }
}
