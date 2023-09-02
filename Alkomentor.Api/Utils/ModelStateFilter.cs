using Microsoft.AspNetCore.Mvc.Filters;

namespace Alkomentor.Api;

public class ModelStateFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var state = context.ModelState;
        context.HttpContext.Features.Set(new ModelStateFeature(state));
        await next();
    }
}