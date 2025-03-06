using System.ComponentModel.DataAnnotations;

namespace WealthTracker.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your email address")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public string? Password { get; set; }
    }
}
