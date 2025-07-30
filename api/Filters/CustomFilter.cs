using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace api.Filters
{
    public class CustomFilter:IExceptionFilter
    {
        private readonly ILogger<CustomFilter> _logger;
        public CustomFilter(ILogger<CustomFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
           var exception=context.Exception;
            var traceId = context.HttpContext.TraceIdentifier;
            _logger.LogError(exception, $"Unhandled exception caught in CustomExceptionFilter TraceId:{traceId}");
            var errorResponse = new
            {
                error = "A handled exception occurred.",
                detail = exception.Message,
                traceId
            };
            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
