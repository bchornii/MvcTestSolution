using System.Diagnostics;
using System.Web.Mvc;

namespace MvcTestPro9_Filters.Infrastructure
{
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch _stopwatch;
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();
            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write($"<div>Method work time: {_stopwatch.Elapsed.TotalSeconds}</div>");
            }
        }
    }
}