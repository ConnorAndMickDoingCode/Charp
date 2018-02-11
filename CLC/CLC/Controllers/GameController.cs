using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLC.Models;
using CLC.Services.Business;

namespace CLC.Controllers
{
    public class GameController : Controller
    {
        public static Game GameLogic { get; set; }

        /**
         * Returns the size-selection view
         */
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Select(Game game)
        {
            GameLogic = game;
            return View();
        }

        [HttpPost]
        public ActionResult Play(Cell cell)
        {
            return View();
        }
    }
}