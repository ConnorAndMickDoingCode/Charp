/*
 version 0.2
 Connor, Mick
 CST-256 
 January 28, 2018 
 This assignment was completed in collaboration with Connor Low, Mick Torres. 
 We used source code from the following websites to complete this assignment: N/ A 
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

            // get results
            bool exists = service.CheckForUsername(user);

            // Check for existing username (no duplicates)
            if (exists)
                return View("Failure");
            service.Register(user);
            return RedirectToAction("Login", "Login");
        }
    }
}