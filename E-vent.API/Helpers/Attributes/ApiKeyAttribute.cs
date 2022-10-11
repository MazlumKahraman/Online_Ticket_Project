using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_vent.API.Helpers.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue("x-api-key",out var incomingApiKey))
            {
                context.Result = new ContentResult() { Content = "Enter api key!", StatusCode = 401 };
                return;
            }
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>("x-api-key");
            if (!apiKey.Equals(incomingApiKey))
            {
                context.Result = new ContentResult() { Content = "Api key not authorized!", StatusCode = 401 };
                return;
            }
            await next();
        }
    }
}
