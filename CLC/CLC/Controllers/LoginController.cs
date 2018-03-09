using CLC.Models;
using CLC.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
                return View("../Default/Index");

            SecurityService service = new SecurityService();

            bool results = service.Authenticate(user);

            if (results)
                return View("UserHomePage");
            return View("LoginFailed");
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("../Default/Index");
        }
    }
}