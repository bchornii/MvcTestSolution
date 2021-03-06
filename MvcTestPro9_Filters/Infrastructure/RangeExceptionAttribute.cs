﻿using System;
using System.Web.Mvc;

namespace MvcTestPro9_Filters.Infrastructure
{
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            {
                //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
                //filterContext.ExceptionHandled = true;
                var val = (int) ((ArgumentOutOfRangeException) filterContext.Exception).ActualValue;
                filterContext.Result = new ViewResult
                {
                    ViewName = "RangeError",                    
                    ViewData = new ViewDataDictionary<int>(val)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}