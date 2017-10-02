
namespace ECTemplate.WebUI.Models
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string ShippingAddress { get; set; }

        public string ShippingAddress2 { get; set; }

        public string ShippingCity { get; set; }

        public string ShippingState { get; set; }

        public string ShippingZip { get; set; }

        public string ShippingCountry { get; set; }

        public string ShippingPhone { get; set; }

        //public string AccountConfirmPassword { get; set; }
    }
}