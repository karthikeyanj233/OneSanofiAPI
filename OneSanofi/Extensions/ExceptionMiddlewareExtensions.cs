﻿
namespace OneSanofi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        //public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<CustomExceptionMiddleware>();
        //}

        //public class CustomExceptionMiddleware
        //{
        //    private readonly RequestDelegate _next;
        //    private readonly ILogger<CustomExceptionMiddleware> _logger;

        //    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        //    {
        //        _logger = logger;
        //        _next = next;
        //    }

        //    public async Task InvokeAsync(HttpContext httpContext)
        //    {
        //        try
        //        {
        //            await _next(httpContext);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Exception occur: {ex}");
        //            await HandleExceptionAsync(httpContext, ex);
        //        }
        //    }

        //    private Task HandleExceptionAsync(HttpContext context, Exception exception)
        //    {
        //        context.Response.ContentType = "application/json";
        //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        //        return context.Response.WriteAsync(new CustomError()
        //        {
        //            StatusCode = context.Response.StatusCode,
        //            Message = "custom middleware error."
        //        }.ToString());
        //    }
        //}
    }
}
