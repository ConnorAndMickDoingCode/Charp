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

        [HttpGet]
        public ActionResult Logout()
        {
            _logger.Info("LoginController::Logout");
            Session.RemoveAll();
            return View("../Default/Index");
        }
    }
}