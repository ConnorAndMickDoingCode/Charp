using CLC2.Models;
using CLC2.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            SecurityService service = new SecurityService();

            // Check for existing username (no duplicates)
            if (service.UsernameExists(user))
                return View("Failure");

            // register user
            service.Register(user);
            ViewBag.SuccessMessage = "<p>Success!</p>";
            return View("../Login/UserHomePage");
        }
    }
}