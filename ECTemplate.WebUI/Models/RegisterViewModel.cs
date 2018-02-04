using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the register info.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        public string UserFirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        public string UserLastName { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("UserPassword", ErrorMessage = "Please comnfirm your password.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the shipping address line 1.
        /// </summary>
        [Required(ErrorMessage = "Address 1 is required.")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address line 2.
        /// </summary>
        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the shipping city.
        /// </summary>
        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string ShippingCity { get; set; }

        /// <summary>
        /// Gets or sets the shipping state.
        /// </summary>
        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string ShippingState { get; set; }

        /// <summary>
        /// Gets or sets the shipping zip.
        /// </summary>
        [Required(ErrorMessage = "Zip is required.")]
        [Display(Name = "Zip")]
        public string ShippingZip { get; set; }

        /// <summary>
        /// Gets or sets the shipping country.
        /// </summary>
        [Required(ErrorMessage = "Country is required.")]
        [Display(Name = "Country")]
        public string ShippingCountry { get; set; }

        /// <summary>
        /// Gets or sets the shipping phone.
        /// </summary>
        [Display(Name = "Phone")]
        public string ShippingPhone { get; set; }
    }
}