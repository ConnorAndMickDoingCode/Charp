using System;
using System.Web.Mvc;
using CLC.Services.Utility;
using Exception = System.Exception;

namespace CLC.Controllers
{
    public class SecurityFilter : FilterAttribute, IAuthorizationFilter
    {
        private readonly ILogger _logger;

        public SecurityFilter()
        {
            _logger = new TheLogger();
        }

        /// <summary>
        /// Checks if a user is logged in by accessing the Session.
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                _logger.Info("-> SecurityFilter.OnAuthorization()");

                // If user is not in session, redirect to login.
                if (filterContext.HttpContext.Session["User"] == null)
                    filterContext.Result = new RedirectResult("/Login");
            }
            catch (Exception e)
            {
                _logger.Error("Error in SecurityFilter: " + e.Message);
            }
        }
    }
}