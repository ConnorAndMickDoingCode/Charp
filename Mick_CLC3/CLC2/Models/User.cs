using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLC2.Models
{
    public class User
    {
        [Required]
        [DisplayName("User Name")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Password { get; set; }
    }
}