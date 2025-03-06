using System.ComponentModel.DataAnnotations;

namespace WealthTracker.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your first name")]
        public required string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your last name")]
        public required string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your email address")]
        public required string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public required string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}
