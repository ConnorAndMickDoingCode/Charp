using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CLC.Models;
using CLC.Services.Data;

namespace CLC.Services.Business
{
    public class LeaderboardService
    {
        public void record(User user, CellGrid grid)
        {
            // create game stat record
            var game = new GameStat
            {
                Username = user.Username,
                Size = grid.Width + "x" + grid.Height,
                Time = grid.Time
            };

            // send to db
            var service = new LeaderboardDAO();
            service.Create(game);
        }
    }
}