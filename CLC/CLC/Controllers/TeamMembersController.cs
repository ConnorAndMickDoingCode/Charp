﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class TeamMembersController : Controller
    {
        // GET: TeamMembers
        public ActionResult Index()
        {
            return View("TeamMembers");
        }
    }
}