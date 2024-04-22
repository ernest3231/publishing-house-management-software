using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShopWebService_ErnestGeorkiani.Filters
{
    public class Logging : Attribute, IActionFilter
    {

        private readonly string _loggerName;

        public Logging(string loggerName)
        {
            _loggerName = loggerName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Sync - Filter Executed Before {_loggerName}");
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Sync - Filter Executed After");
        }
    }
}
