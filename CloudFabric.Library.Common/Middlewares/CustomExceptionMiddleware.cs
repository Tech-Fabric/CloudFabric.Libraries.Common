using CloudFabric.Library.Common.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Middlewares
{
    public static class CFCommonMiddlewareExtensions
    {
        public static IApplicationBuilder UseCFCommonMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
    public class CustomExceptionMiddleware
    {
        private RequestDelegate _next;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            _next = next;
            _logger = logger.CreateLogger("Global Exception Filter");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException ex)
            {
                context.Response.StatusCode = (int)(ex).Status();
                byte[] message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ex.Body()));

                /*
                * Pay attention down here
                * VVVVVVVVVVVVVVVVVVVVVVV
                */

                context.Response.ContentType = "application/json";
                context.Response.ContentLength = message.Length;
                context.Response.Body.WriteAsync(message, 0, message.Length);
            }

        }
    }
}
