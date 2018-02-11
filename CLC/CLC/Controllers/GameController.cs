using System;
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