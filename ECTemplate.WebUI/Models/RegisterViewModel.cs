using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("UserPassword", ErrorMessage = "Please comnfirm your password.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Address 1 is required.")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress { get; set; }

        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string ShippingState { get; set; }

        [Required(ErrorMessage = "Zip is required.")]
        [Display(Name = "Zip")]
        public string ShippingZip { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [Display(Name = "Country")]
        public string ShippingCountry { get; set; }

        [Display(Name = "Phone")]
        public string ShippingPhone { get; set; }
    }
}