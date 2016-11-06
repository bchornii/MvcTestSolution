using System;
using System.Web.Mvc;

namespace MvcTestPro9_Filters.Infrastructure
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        private readonly bool _isLocalAllowed;

        public CustomActionAttribute(bool isLocalAllowed)
        {
            _isLocalAllowed = isLocalAllowed;
        }
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal && !_isLocalAllowed)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}