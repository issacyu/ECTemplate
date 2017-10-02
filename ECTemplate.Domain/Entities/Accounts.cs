using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string UserLastName { get; set; }

        public string UserType { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public int UserAddressId { get; set; }
    }
}
