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

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string ShippingLastName { get; set; }

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

        [ForeignKey("UserId")]
        public virtual Accounts Account { get; set; }
    }
}
