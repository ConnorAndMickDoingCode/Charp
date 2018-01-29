using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSWA_Milestone2.Models;
using MSWA_Milestone2.Services.Business;

namespace MSWA_Milestone2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            SecurityService SecServ = new SecurityService();
            bool results = SecServ.Authenticate(user);

            if (results)
            {
                return View("UserHomePage");
            }
            else
            {
                return
                    View("LoginFailed");
            }
        }
    }
}