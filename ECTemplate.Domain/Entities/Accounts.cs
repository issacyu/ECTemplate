using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class that stores the data in the Account table.
    /// </summary>
    public class Accounts
    {
        /// <summary>
        /// The primary key of the Accounts table. This is an identity column and the key will 
        /// generate automatically.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        [Required(ErrorMessage = "First Name is required.")]
        public string UserFirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        [Required(ErrorMessage = "Last Name is required.")]
        public string UserLastName { get; set; }

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        /// <summary>
        /// The foreign key that points to the Address table.
        /// </summary>
        [ForeignKey("Address")]
        public Guid AddressId { get; set; }

        /// <summary>
        /// The navigation property of the Address table which associate to this user.
        /// </summary>
        public virtual Addresses Address { get; set; }

        /// <summary>
        /// The navigaion collection of the orders in the Order which associate to this user.
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
