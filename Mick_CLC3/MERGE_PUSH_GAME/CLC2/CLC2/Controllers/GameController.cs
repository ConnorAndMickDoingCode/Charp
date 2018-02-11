using CLC2.Models;
using CLC2.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC2.Controllers
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
            if (size.Equals("Large"))
                GameLogic = new Game(16, 16, 40);
            else if (size.Equals("Medium"))
                GameLogic = new Game(12, 12, 22);
            else // if (size.Equals("Small"))
                GameLogic = new Game(9, 9, 12);

            return View("Game", GameLogic);
        }

        [HttpPost]
        public ActionResult Play(Cell cell)
        {
            GameLogic.Check(cell.X, cell.Y);
            return View("Game", GameLogic);
        }
    }
}