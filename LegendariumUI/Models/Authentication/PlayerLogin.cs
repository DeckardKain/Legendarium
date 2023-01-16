using System.ComponentModel.DataAnnotations;

namespace LegendariumUI.Models.Authentication
{
    public class PlayerLogin
    {
        [EmailAddress]
        [Required(ErrorMessage = "Error: Email Address is Required.")]
        public string Email { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
