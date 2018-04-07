using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CLC.Models;
using CLC.Services.Data;
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

        public void SaveGame(User user, string json)
        {
            // call data service and pass JSON
            Service.Create(user, json);
        }

        public CellGrid LoadGame(int id)
        {
            // call data base method to get JSON
            var json = Service.Read(id);

            // parse JSON into CellGrid and return
            return JsonConvert.DeserializeObject<CellGrid>(json);
        }
    }
}