using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class SecurityFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if ()
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}