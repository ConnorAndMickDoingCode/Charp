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
            // instantiate Business service
            SecurityService service = new SecurityService();

            // get results
            bool results = service.Authenticate(user);

            // ? return home : return failure
            if (results)
                return View("UserHomePage");
            return View("LoginFailed");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("Login");
        }
    }
}