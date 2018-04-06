using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Topic4.Services.Utility;

namespace Topic4.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var data = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "::" +
                       filterContext.ActionDescriptor.ActionName;
            CaptainsLogger.getInstace().Info(data + " starting");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var data = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "::" +
                       filterContext.ActionDescriptor.ActionName;
            CaptainsLogger.getInstace().Info(data + " finished");
        }
    }
}