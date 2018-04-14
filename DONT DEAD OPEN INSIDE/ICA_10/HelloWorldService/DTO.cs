using ICA_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HelloWorldService
{
    [DataContract]
    public class DTO
    {
        public DTO(int ErrorCode, string ErrorMsg, List<UserModel> Data)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMsg = ErrorMsg;
            this.Data = Data;
        }
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }
        [DataMember]
        public List<UserModel> Data { get; set; }
    }
}