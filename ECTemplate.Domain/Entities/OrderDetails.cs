using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class that stores the data in the OrderDetails table.
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// The primary key of the OrderDetails table. This is an identity column and the key will 
        /// generate automatically.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        /// <summary>
        /// Gets or sets the detail ID.
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// The foreign key that points to the Order table.
        /// </summary>
        [ForeignKey("Order")]
        public Guid DetailOrderId { get; set; }

        /// <summary>
        /// Gets or sets the detail product ID.
        /// </summary>
        public int DetailProductId { get; set; }

        /// <summary>
        /// Gets or sets the detail price.
        /// </summary>
        public decimal DetailPrice { get; set; }

        /// <summary>
        /// Gets or sets the detail quantity.
        /// </summary>
        public int DetailQuantity { get; set; }

        /// <summary>
        /// The navigation property of the Order table which associate to this order detail.
        /// </summary>
        public Orders Order { get; set; }
    }
}
