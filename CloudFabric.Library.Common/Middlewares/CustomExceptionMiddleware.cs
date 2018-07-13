using CloudFabric.Library.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Middlewares
{
    public class CustomExceptionMiddleware 
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BaseException exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)exception.Status();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(exception.Body());

                return;
            }
        }
    }
}
