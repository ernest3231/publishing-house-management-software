using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShopWebService_ErnestGeorkiani.Filters
{
    public class LoggingAsync : Attribute, IAsyncActionFilter
    {

        private readonly string _loggerName;

        public LoggingAsync(string loggerName)
        {
            _loggerName = loggerName;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Async - Before the request execute {_loggerName}");
            await next();
            Console.WriteLine($"Async - After the request execute {_loggerName}");
        }
    }   
}
