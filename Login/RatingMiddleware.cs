﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Services;
using Entity;

namespace Login
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
    

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
           

        }

        public async  Task Invoke(HttpContext httpContext, IRatingService _ratingService)
        {
            Rating rating = new Rating();

            rating.Host = httpContext.Request.Host.Host;
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Headers.Referer;
            rating.UserAgent = httpContext.Request.Headers.UserAgent;
            rating.RecordDate = DateTime.Now;

            await _ratingService.CreatRating(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
