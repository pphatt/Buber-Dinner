﻿using System.Net;
using System.Text.Json;

namespace Server.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        } 
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = "An error occurred while processing your request." });

        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(result);
    }
}
