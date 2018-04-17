using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CLC.Models;
using CLC.Services.Business;

namespace MinesweeperStatsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StatsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StatsService.svc or StatsService.svc.cs at the Solution Explorer and start debugging.
    public class StatsService : IStatsService
    {
        public DTO GetLeaderboard()
        {
            // get leaderboards from db
            var service = new LeaderboardService();
            var data = service.getLeaderboards();

            // determine response messages and error code
            var ok = data.Count > 0;
            var errorCode = ok ? 200 : 404;
            var statusMessage = ok ? "Success" : "No Results";

            // ship it
            var dto = new DTO(errorCode, statusMessage, data);
            return dto;
        }
    }
}
