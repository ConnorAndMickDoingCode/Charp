using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLC.Models
{
    public class User
    {
        [Required]
        [DisplayName("Username")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters")]
        [DefaultValue("")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters")]
        [DefaultValue("")]
        public string Password { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(20, ErrorMessage = "First name must be under 20 characters")]
        [DefaultValue("")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(20, ErrorMessage = "Last name must be under 20 characters")]
        [DefaultValue("")]
        public string LastName { get; set; }
    }
}