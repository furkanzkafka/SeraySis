using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraySis.WebApp.Filters
{
    public class ErrorHandle : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.TempData["LastError"] = filterContext.Exception;

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Hata");
        }
    }
}