using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SteelPlantAPI7292023.Filtres
{
    public class LogFilter : IActionFilter
    {
        private readonly ILogger<LogFilter> _logger;

        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Finished method " + context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            _logger.LogInformation("Started method " + context.ActionDescriptor.DisplayName);
        }
    }
}
