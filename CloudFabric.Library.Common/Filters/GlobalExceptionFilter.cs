using CloudFabric.Library.Common.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;

namespace CloudFabric.Library.Common.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(IHostingEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            this.env = env;
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);



            var errorDetails = new ErrorDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Detail = "Please refer to the errors property for additional details.",
                Errors = { },
            };

            if (context.Exception is BaseException)
            {
                var bException = (BaseException)context.Exception;
                errorDetails.Errors.Add(context.Exception.GetType().Name, new[] { bException.Body() });
                errorDetails.Status = (int)bException.Status();
                context.Result = new ObjectResult(errorDetails)
                {
                    StatusCode = (int)bException.Status()
                };
                context.HttpContext.Response.StatusCode = (int)bException.Status();
            }
            else if (context?.ModelState?.IsValid == false)
            {
                foreach (var key in context.ModelState.Keys)
                {
                    ModelStateEntry val;
                    context.ModelState.TryGetValue(key, out val);

                    errorDetails.Errors.Add(key, val?.Errors?.Select(e => e.ErrorMessage).ToArray());
                }
                errorDetails.Status = (int)HttpStatusCode.BadRequest;
                context.Result = new ObjectResult(errorDetails)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context?.Exception is ValidationException)
            {
                var vException = (ValidationException)context.Exception;
                errorDetails.Errors.Add(context.Exception.GetType().Name, new[] { vException.Message });
                errorDetails.Status = (int)HttpStatusCode.BadRequest;
                context.Result = new ObjectResult(errorDetails)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                errorDetails.Errors.Add("ServerError", new[] { "An unexpected error ocurred." });

                context.Result = new ObjectResult(errorDetails)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            if (env.IsDevelopment())
            {
                errorDetails.Exception = context.Exception;
            }



            context.ExceptionHandled = true;
        }

        private class ErrorDetails : ValidationProblemDetails
        {
            public Exception Exception { get; set; }
        }
    }
}
