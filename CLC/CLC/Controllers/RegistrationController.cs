﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class RegistrationController : Controller
    { 
        // GET: Registration
        public ActionResult Index()
        {
            return View("Registration"); // ckeul ckattz
        }
    }
}