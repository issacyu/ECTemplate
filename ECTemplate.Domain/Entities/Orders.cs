using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class that stores the data in the Orders table.
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// The primary key of the Order table.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        /// <summary>
        /// Gets or sets order ID.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets order amount.
        /// </summary>
        public double OrderAmount { get; set; }

        /// <summary>
        /// Gets or sets order shipping address.
        /// </summary>
        public string OrderShipAddress { get; set; }

        /// <summary>
        /// Gets or sets order shipping address line 2.
        /// </summary>
        public string OrderShipAddress2 { get; set; }

        /// <summary>
        /// Gets or sets order city.
        /// </summary>
        public string OrderCity { get; set; }

        /// <summary>
        /// Gets or sets order state.
        /// </summary>
        public string OrderState { get; set; }

        /// <summary>
        /// Gets or sets the order zip.
        /// </summary>
        public string OrderZip { get; set; }

        /// <summary>
        /// Gets or sets order country.
        /// </summary>
        public string OrderCountry { get; set; }

        /// <summary>
        /// Gets or sets order phone.
        /// </summary>
        public string OrderPhone { get; set; }

        /// <summary>
        /// Gets or sets order date.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets order status.
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// The foreign key which points to the Account table.
        /// </summary>
        [ForeignKey("Account")]
        public int OrderAccount { get; set; }

        /// <summary>
        /// The navigation property of the Account table which associate to this orders.
        /// </summary>
        public Accounts Account { get; set; }

        /// <summary>
        /// The navigation collection of the OrderDetails table which associate to this order detail.
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
