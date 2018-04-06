using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Topic4.Models
{
    [DataContract]
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
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