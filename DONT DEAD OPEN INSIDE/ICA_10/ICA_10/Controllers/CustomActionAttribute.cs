using ICA_10.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA_10.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            CaptainsLogger.getInstace().Info("Exiting Controller ... " + name);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            CaptainsLogger.getInstace().Info("Entering Controller ... " + name);
        }
    }
}