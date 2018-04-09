using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MinesweeperStatsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StatsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StatsService.svc or StatsService.svc.cs at the Solution Explorer and start debugging.
    public class StatsService : IStatsService
    {
        public DTO GetAll()
        {
            throw new NotImplementedException();
        }

        public DTO GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
