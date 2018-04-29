using System;
using System.Web.Mvc;
using CLC.Models;
using CLC.Services.Engine;
using CLC.Services.Business;
using CLC.Services.Utility;
using Newtonsoft.Json;

namespace CLC.Controllers
{
    /// <summary>
    /// Controller for games.
    /// <para>Handles the saving, loading, and playing of games.</para>
    /// </summary>
    public class GameController : Controller
    {
        private readonly ILogger _logger;

        public GameController(ILogger logger)
        {
            _logger = logger;
        }

        public static Game GameLogic { get; set; }

        // GET: Game
        /// <summary>
        /// Returns the view for selecting game to begin/continue.
        /// </summary>
        /// <returns>A game selection view.</returns>
        [HttpGet]
        [SecurityFilter]
        public ActionResult Index()
        {
            _logger.Info("-> Game.Index()");
            try
            {
                // get user from session
                var user = (Session["user"] is User u) ? u : null;

                // if the user is in the session, retrieve saved games
                if (user != null)
                {
                    // get saved games from database for the user
                    var service = new GameStateService();
                    var games = service.GetSavedGames(user);

                    // pass array of games to select service
                    return View("Select", games);
                }

                // else, return select view.
                return View("Select");
            }
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
                return View("Error");
            }
        }

        /// <summary>
        /// Creates a new gameboard of selected size and renders the game board view.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>A game board view.</returns>
        [HttpPost]
        [SecurityFilter]
        public ActionResult Select(String size)
        {
            _logger.Info("-> Game.Select(" + size + ")");
            try
            {
                if (size.Equals("large"))
                    GameLogic = new Game(16, 16, 40);
                else if (size.Equals("medium"))
                    GameLogic = new Game(12, 12, 22);
                else // if (size.Equals("small"))
                    GameLogic = new Game(9, 9, 12);
                return View("Game", GameLogic.Grid);
            }
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
                return View("Error");
            }
        }

        /// <summary>
        /// Updates the game engine and returns the updated board.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="cell"></param>
        /// <returns>A partial view with an updated minesweeper board.</returns>
        [HttpPost]
        [SecurityFilter]
        public PartialViewResult Play(String time, String cell)
        {
            _logger.Info("-> Game.Play(" + time + ", " + cell.ToString() + ")");
            try
            {
                // run cell check logic
                GameLogic.UpdateState(cell, time);

                // end game conditions
                if (GameLogic.Grid.Win || GameLogic.Grid.Lose)
                {
                    // remove the game from user's saved games
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
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
                return PartialView("_Board", GameLogic.Grid);
            }
        }

        /// <summary>
        /// Save a game in the database
        /// </summary>
        /// <param name="time"></param>
        [HttpPost]
        [SecurityFilter]
        public void Save(string time)
        {
            _logger.Info("-> Game.Index()");
            try
            {
                // update time
                GameLogic.Grid.Time = int.Parse(time);

                // save game
                if (!GameLogic.Grid.Lose)
                    SaveGameState();
            }
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Calls services for saving game state.
        /// </summary>
        private void SaveGameState()
        {
            _logger.Info("-> Game.SaveGameState()");
            try
            {
                // make sure user is logged in
                if (Session["user"] != null)
                {
                    // save JSON in DB
                    var service = new GameStateService();

                    // if game has not been saved yet, ID will be one. Create new save and update ID
                    if (GameLogic.Grid.Id == -1)
                        GameLogic.Grid.Id = service.SaveGame((User) Session["user"], GameLogic.Grid);

                    // else, update existing game
                    else
                        service.UpdateGame(GameLogic.Grid);
                }
            }
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Load a game board from a saved game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [SecurityFilter]
        public ActionResult LoadGame(int id)
        {
            _logger.Info("-> Game.LoadGame(" + id + "");
            try
            {
                // get game by id
                var service = new GameStateService();
                var grid = service.LoadGame(id);

                // create GameLogic using grid data
                GameLogic = new Game(grid.Width, grid.Height, grid.Mines) {Grid = grid};

                // return Game view with grid
                return View("Game", GameLogic.Grid);
            }
            catch (Exception e)
            {
                _logger.Error("Error in Game Controller");
                Console.WriteLine(e);
                return View("Error");
            }
        }
    }
}