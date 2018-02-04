using System.ComponentModel.DataAnnotations;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the address info.
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required(ErrorMessage = "The first name is required.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required(ErrorMessage = "The last name is required.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        [Required(ErrorMessage = "The address is required.")]
        [Display(Name = "Line 1")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        [Display(Name = "Line 2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required(ErrorMessage = "The city is required.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Required(ErrorMessage = "The state is required.")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [Required(ErrorMessage = "The zip is required.")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [Required(ErrorMessage = "The country is required.")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }
    }
}