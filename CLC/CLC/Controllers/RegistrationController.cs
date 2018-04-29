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
    /// <summary>
    /// Controller for registration of new users.
    /// </summary>
    public class RegistrationController : Controller
    {
        private readonly ILogger _logger;

        public RegistrationController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: Registration
        public ActionResult Index()
        {
            _logger.Info("-> Registration.Register()");
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            _logger.Info("-> Registration.Register()");
            try
            {
                if (!ModelState.IsValid)
                    return View("../Default/Index");

                SecurityService service = new SecurityService();


                // Check for existing username (no duplicates)
                if (service.UsernameExists(user))
                    return View("Failure");

                // register user
                service.Register(user);
                ViewBag.SuccessMessage = "<p>Success!</p>";
                return View("../Login/UserHomePage");
            }
            catch (Exception e)
            {
                _logger.Error("Error in Registration Controller");
                Console.WriteLine(e);
                return View("Error");
            }
        }
    }
}