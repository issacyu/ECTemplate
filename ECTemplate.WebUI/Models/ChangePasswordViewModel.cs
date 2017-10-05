using System.ComponentModel.DataAnnotations;


namespace ECTemplate.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Current password is required.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Please comnfirm your password.")]
        public string ConfirmPassword { get; set; }
    }
}