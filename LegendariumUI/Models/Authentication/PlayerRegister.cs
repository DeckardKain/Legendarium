using System.ComponentModel.DataAnnotations;

namespace LegendariumUI.Models.Authentication
{
    public class PlayerRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Error: Username Max Characters is 16")]
        public string Username { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Error: Password do not match.")]
        public string ConfirmPassword { get; set; }

        public DateTime BirthDay { get; set; } = DateTime.Now;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Only confirmed users can play!")]
        public bool IsConfirmed { get; set; } = true;
    }
}
