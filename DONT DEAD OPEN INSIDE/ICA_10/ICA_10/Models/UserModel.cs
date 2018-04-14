using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ICA_10.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        private string v1;
        [DataMember]
        private string v2;

        public UserModel(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        [Required]
        [DisplayName("Username")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        [DataMember]
        public String Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        [DataMember]
        public String Password { get; set; }
    }
}