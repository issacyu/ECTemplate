using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    public class Addresses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int  AddressId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [Display(Name = "Last Name")]
        public string ShippingLastName { get; set; }

        [Required(ErrorMessage = "Please enter the first address line.")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress { get; set; }

        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name.")]
        [Display(Name = "City")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Please enter a state name.")]
        [Display(Name = "State")]
        public string ShippingState { get; set; }

        [Required(ErrorMessage = "Please enter a zip code.")]
        [Display(Name = "Zip")]
        public string ShippingZip { get; set; }

        [Required(ErrorMessage = "Please enter a country name.")]
        [Display(Name = "Country")]
        public string ShippingCountry { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Display(Name = "Phone")]
        public string ShippingPhone { get; set; }

        [ForeignKey("UserId")]
        public virtual Accounts Account { get; set; }
    }
}
