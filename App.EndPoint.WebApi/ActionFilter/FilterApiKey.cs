using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ApiKeyAuthFilter : IActionFilter
{
    private const string ApiKeyHeaderName = "X-Api-Key";
    private readonly string _apiKey;

    public ApiKeyAuthFilter(IConfiguration configuration)
    {
        _apiKey = configuration["ApiKey"];
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (apiKey != _apiKey)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}