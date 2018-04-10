using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CLC.Models;
using CLC.Services.Data;
using CLC.Services.Engine;
using Newtonsoft.Json;

namespace CLC.Services.Business
{
    public class GameStateService
    {
        private readonly GameStateDAO Service;

        public GameStateService()
        {
            Service = new GameStateDAO();
        }

        public int SaveGame(User user, CellGrid game)
        {
            // get next id in db
            game.Id = Service.GetNextId();

            // serialize Grid into JSON
            var json = JsonConvert.SerializeObject(game);

            // call data service and pass JSON
            return Service.Create(user, json);
        }

        public void UpdateGame(CellGrid game)
        {
            // serialize Grid into JSON
            var json = JsonConvert.SerializeObject(game);
            // call data service and pass JSON
            Service.Update(json, game.Id);
        }

        public void DeleteGame(int id)
        {
            // call data service and pass JSON
            Service.Delete(id);
        }

        public CellGrid LoadGame(int id)
        {
            // call data base method to get JSON
            var json = Service.Read(id);

            // parse JSON into CellGrid and return
            return JsonConvert.DeserializeObject<CellGrid>(json);
        }

        public List<CellGrid> GetSavedGames(User user)
        {
            // call data base method to get JSON
            var json = Service.Read(user);

            // parse JSON into a list of CellGrid objects and return
            List<CellGrid> games = new List<CellGrid>();
            foreach (var e in json)
            {
                games.Add(JsonConvert.DeserializeObject<CellGrid>(e));
            }

            return games;
        }
    }
}