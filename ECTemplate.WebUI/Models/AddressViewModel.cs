using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the first address line.")]
        [Display(Name = "Line 1")]
        public string Address { get; set; }

        [Display(Name = "Line 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name.")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }
    }
}