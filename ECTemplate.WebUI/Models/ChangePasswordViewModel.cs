using System.ComponentModel.DataAnnotations;

/// <summary>
/// The view model that uses to bind to the view that cantains the change password info.
/// </summary>
namespace ECTemplate.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Gets or sets the current password.
        /// </summary>
        [Required(ErrorMessage = "Current password is required.")]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Please comnfirm your password.")]
        public string ConfirmPassword { get; set; }
    }
}