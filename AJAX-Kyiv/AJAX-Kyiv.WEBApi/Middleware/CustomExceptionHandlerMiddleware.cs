﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using FluentValidation;
using System.Net;
using System.Text.Json;
using Footballers.Application.Common.Exceptions;

namespace AJAX_Kyiv.WEBApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception) 
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == null)
            {
                result = JsonSerializer.Serialize(new {error = exception.Message});
            }

            return context.Response.WriteAsync(result);
        }
    }
}
