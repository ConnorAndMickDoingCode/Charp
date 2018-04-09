using System;
using System.Web.Mvc;
using CLC.Models;
using CLC.Services.Engine;
using CLC.Services.Business;
using Newtonsoft.Json;

namespace CLC.Controllers
{
    public class GameController : Controller
    {
        public static Game GameLogic { get; set; }
        public static int MoveCount { get; set; }

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
        public PartialViewResult Play(String time, String cell)
        {
            // parse request string
            var c = cell.Split(',');
            var x = int.Parse(c[0]);
            var y = int.Parse(c[1]);

            // check if initialized (prevent instant-deaths)
            if (!GameLogic.Started)
                GameLogic.InitCells(x, y);

            // update game board
            GameLogic.Check(x, y);

            // update time
            GameLogic.Grid.Time = int.Parse(time);

            // Save if not recently saved
            MoveCount++;
            if (MoveCount % 3 == 0)
                SaveGameState();

            // return game-board partial view
            return PartialView("_Board", GameLogic.Grid);
        }

        [HttpGet]
        public void Save(string time)
        {
            // update time
            GameLogic.Grid.Time = int.Parse(time);

            // save game
            SaveGameState();
        }

        private void SaveGameState()
        {
            // make sure user is logged in
            if (Session["user"] == null)
            {

            }
            else
            {
                // serialize Grid into JSON
                var json = JsonConvert.SerializeObject(GameLogic.Grid);

                // save JSON in DB
                var service = new GameStateService();
                service.SaveGame((User) Session["user"], json);
            }
        }

        private void LoadGame()
        {
          if(GameLogic.Started == true)
            {
                
            }
        }
    }
}