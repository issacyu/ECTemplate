using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The email is required.")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The password is required.")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsRememberMe { get; set; }
    }
}