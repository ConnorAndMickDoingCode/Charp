using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CLC.Models;

namespace MinesweeperStatsService
{
    [DataContract]
    public class DTO
    {
        public DTO(int status, string message, List<GameStat> data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        [DataMember] public int Status { get; set; }
        [DataMember] public string Message { get; set; }
        [DataMember] public List<GameStat> Data { get; set; }
    }
}