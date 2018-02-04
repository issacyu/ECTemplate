using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the login info.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Required(ErrorMessage = "The email is required.")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required(ErrorMessage = "The password is required.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the is remember me.
        /// </summary>
        [Display(Name = "Remember Me")]
        public bool IsRememberMe { get; set; }
    }
}