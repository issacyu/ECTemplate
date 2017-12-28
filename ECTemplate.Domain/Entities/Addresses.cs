using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class that stores the data in the Addresses table.
    /// </summary>
    public class Addresses
    {
        /// <summary>
        /// The primary key of the Addresses table. This is an identity column and the key will.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping first name.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string ShippingFirstName { get; set; }

        /// <summary>
        /// Gets or sets the shipping last name.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string ShippingLastName { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
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
