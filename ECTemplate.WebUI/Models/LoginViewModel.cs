using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsRememberMe { get; set; }
    }
}