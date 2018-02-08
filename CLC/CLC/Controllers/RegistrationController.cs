/*
 version 0.2
 Connor, Mick
 CST-256 
 January 28, 2018 
 This assignment was completed in collaboration with Connor Low, Mick Torres. 
 We used source code from the following websites to complete this assignment: N/A 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLC.Models;
using CLC.Services.Business;

namespace CLC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("Registration"); // ckeul ckattz
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            // instantiate Business service
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