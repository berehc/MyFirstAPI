﻿namespace MyFirstAPI.Middlewares
{
    public class TimeMeddleware
    {
        readonly RequestDelegate next;

        public TimeMeddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            await next(context);

            if(context.Request.Query.Any(p=> p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }

    }

    public static class TimeMiddleWareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMeddleware>();
        }
    }
}
