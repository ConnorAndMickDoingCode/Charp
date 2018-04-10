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
                Time = grid.Time,
                Count = grid.Count
            };

            // send to db
            var service = new LeaderboardDAO();
            service.Create(game);
        }

        public List<GameStat> getLeaderboards()
        {
            var service = new LeaderboardDAO();
            var list = service.Read();
            List<GameStat> result = new List<GameStat>();
            foreach (var item in list)
            {
                result.Add(new GameStat()
                {
                    Id = Int32.Parse(item[0]),
                    Username = item[1],
                    Size = item[2],
                    Time = Int32.Parse(item[3]),
                    Count = Int32.Parse(item[4])
                });
            }

            return result;
        }
    }
}