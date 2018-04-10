using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CLC.Models
{
    [DataContract]
    public class GameStat
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public int Time { get; set; }
        [DataMember] public int Count { get; set; }
        [DataMember] public string Size { get; set; }
        [DataMember] public string Username { get; set; }
    }
}