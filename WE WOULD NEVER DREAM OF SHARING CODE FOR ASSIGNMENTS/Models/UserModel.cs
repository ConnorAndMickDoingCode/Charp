using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Topic4.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("Username")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public String Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public String Password { get; set; }
    }
}