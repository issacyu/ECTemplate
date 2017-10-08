using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "The first name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The address is required.")]
        [Display(Name = "Line 1")]
        public string Address { get; set; }

        [Display(Name = "Line 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "The city is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "The zip is required.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "The country is required.")]
        public string Country { get; set; }

        public string Phone { get; set; }
    }
}