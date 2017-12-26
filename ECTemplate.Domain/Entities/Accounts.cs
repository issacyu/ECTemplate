using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("Address")]
        public Guid AddressId { get; set; }

        public virtual Addresses Address { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
