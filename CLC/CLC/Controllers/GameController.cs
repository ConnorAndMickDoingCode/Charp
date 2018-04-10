using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // GET: Game
        [HttpGet]
        public ActionResult Index()
        {
            User user = (Session["user"] is User) ? (User) Session["user"] : null;

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
            // run cell check logic
            GameLogic.UpdateState(cell, time);

            // end game conditions
            if (GameLogic.Grid.Win || GameLogic.Grid.Lose)
            {
                GameLogic.EndGame((User) Session["user"]);

                // return view
                return PartialView("_Board", GameLogic.Grid);
            }

            // Save if not recently saved
            if (GameLogic.Grid.Moves % 3 == 0)
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
                // TODO 
            }
            else
            {
                // serialize Grid into JSON
                var json = JsonConvert.SerializeObject(GameLogic.Grid);

                // save JSON in DB
                var service = new GameStateService();

                // if game has not been saved yet, ID will be one. Create new save and update ID
                if (GameLogic.Grid.Id == -1)
                    GameLogic.Grid.Id = service.SaveGame((User) Session["user"], json);

                // else, update existing game
                else
                    service.UpdateGame(GameLogic.Grid.Id, json);
            }
        }

        [HttpPost]
        public ActionResult LoadGame(int id)
        {
            // get game by id
            var service = new GameStateService();
            var grid = service.LoadGame(id);

            // create GameLogic using grid data
            GameLogic = new Game(grid.Width, grid.Height, grid.Mines) {Grid = grid};

            // return Game view with grid
            return View("Game", GameLogic.Grid);
        }
    }
}