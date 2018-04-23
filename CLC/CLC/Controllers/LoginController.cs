using CLC.Models;
using CLC.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLC.Services.Utility;

namespace CLC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger _logger;

        public LoginController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            _logger.Info("LoginController::Index");
            return View("../Default/Index");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                _logger.Info("LoginController::Login");
                if (!ModelState.IsValid)
                    return View("../Default/Index");

                SecurityService service = new SecurityService();

                bool results = service.Authenticate(user);

                if (!results)
                    return View("LoginFailed");
                Session["user"] = user;
                return View("UserHomePage");
            }
            catch (Exception e)
            {
                _logger.Error("Error in Login: " + e);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                _logger.Info("LoginController::Logout");
                Session.RemoveAll();
                return View("../Default/Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Home()
        {
            var user = (Session["user"] is User u) ? u : null;
            if (user != null)
            {
                return View("UserHomePage");
            }
            return View("../Default/Index");
        }
    }
}