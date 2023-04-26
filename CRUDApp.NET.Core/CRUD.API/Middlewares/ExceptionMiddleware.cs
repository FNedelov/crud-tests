using CRUD.API.Interfaces;
using CRUD.Common;
using CRUD.Common.DTOs;
using Microsoft.AspNetCore.Authentication;
using System.Net;

namespace CRUD.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /* IEventService is registered as a scoped service, in Program.cs. 
           This means that you can not inject it as a constructor parameter in Middleware because only Singleton services can be resolved by constructor injection in Middleware.
           In this case dependency has to be moved to the Invoke method*/
        public async Task InvokeAsync(HttpContext httpContext, IEventService eventService)
        {
            RequestDataDto requestData = new()
            {
                RequestPath = httpContext.Request.Path.ToString(),
                RequestInitiator = httpContext.Request.Headers.Select(x => x).FirstOrDefault(y => y.Key == Constants.HEADER_USER).Value,
                AccessToken = await httpContext.GetTokenAsync(Constants.TOKEN_NAME)
            };

            try
            {
                // Avoid double logging in case of client side error.
                if (!requestData.RequestPath.Contains("Event/CreateEvent"))
                    await eventService.CreateEvent(requestData);

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                requestData.Description = $"{ex.Message} - { ex.StackTrace}";
                await eventService.CreateEvent(requestData);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new ErrorDetailsDto()
            {
                StatusCode = context.Response.StatusCode,
                ExceptionType = ex.GetType().Name,
                InnerException = ex.InnerException?.ToString() ?? "There is no inner exception",
                Message = ex.Message
            }.ToString());
        }
    }
}