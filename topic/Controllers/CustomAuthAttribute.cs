using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Topic4.Controllers
{
    public class CustomAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Oh hi Mark
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}