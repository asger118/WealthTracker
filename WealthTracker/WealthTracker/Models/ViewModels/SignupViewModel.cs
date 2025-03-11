using System.ComponentModel.DataAnnotations;

namespace WealthTracker.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your last name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
