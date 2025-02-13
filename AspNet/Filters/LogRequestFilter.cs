using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNet.Filters
{
    public class LogRequestFilter : IActionFilter
    {
        // init and inject logger
        private readonly ILogger<LogRequestFilter> _logger;
        public LogRequestFilter(ILogger<LogRequestFilter> logger)
        {
            _logger = logger;
        }

        // override method to log information before the action executes
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log information before the action executes
            _logger.LogInformation($"Action Method {context.ActionDescriptor.DisplayName} is about to execute.");

            // Optionally, you can log request details
            _logger.LogInformation($"Request Path: {context.HttpContext.Request.Path}, Method: {context.HttpContext.Request.Method}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Log information after the action executes
            if (context.Exception != null)
            {
                _logger.LogError(context.Exception, "An exception occurred in the action method.");
            }
            else
            {
                _logger.LogInformation("Action Method {ActionName} executed successfully.", context.ActionDescriptor.DisplayName);
            }
        }
    }
}
