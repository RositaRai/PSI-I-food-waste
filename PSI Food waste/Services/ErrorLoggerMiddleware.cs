// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;

namespace PSI_Food_waste.Services
{
    public class ErrorLoggerMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _enviroment;
        public ErrorLoggerMiddleware(RequestDelegate next, ILogger logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _next = next;
            _enviroment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                await LogError(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMsg = "Internal server erorr happened. Contact supoort";
            if (_enviroment.IsDevelopment())
            {
                errorMsg = JsonConvert.SerializeObject(ex, Formatting.Indented);
            }
            return context.Response.WriteAsync(new { Message = errorMsg }.ToString());
        }
        private async Task LogError(HttpContext context, Exception ex)
        {
            context.Request.EnableBuffering();
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                _logger.Error(
                    ex,
                    $"Exception accured, Method: {context.Request.Method}, Context: {context.Request.GetDisplayUrl()}",
                    JsonConvert.SerializeObject(body));
                context.Request.Body.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}
