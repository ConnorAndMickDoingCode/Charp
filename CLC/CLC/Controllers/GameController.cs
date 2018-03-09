using CLC.Models;
using CLC.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class GameController : Controller
    {
        public static Game GameLogic { get; set; }

        // GET: Game
        [HttpGet]
        public ActionResult Index()
        {
            return View("Select");
        }

        [HttpPost]
        public ActionResult Select(String size)
        {
            if (size.Equals("large"))
                GameLogic = new Game(16, 16, 40);
            else if (size.Equals("medium"))
                GameLogic = new Game(12, 12, 22);
            else // if (size.Equals("small"))
                GameLogic = new Game(9, 9, 12);

            return View("Game", GameLogic.Grid);
        }

        [HttpPost]
        public ActionResult Play(String cell)
        {
            var c = cell.Split(',');
            var x = int.Parse(c[0]);
            var y = int.Parse(c[1]);
            GameLogic.Check(x, y);
            return PartialView("_Board", GameLogic.Grid);
        }
    }
}