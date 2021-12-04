using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebUI.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSettings;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

            _jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(
                        Result.Failure(validationException.Failures.Values),
                        _jsonSettings
                    );
                    break;
                case BadRequestException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case Exception _:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(
                        Result.Failure(new List<string> { "An internal server error occured" }),
                        _jsonSettings
                    );
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(
                    Result.Failure(new List<string> { exception.Message }),
                    _jsonSettings
                );
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
