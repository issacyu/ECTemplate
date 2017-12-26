using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        [ForeignKey("Order")]
        public Guid DetailOrderId { get; set; }
        public int DetailProductId { get; set; }
        public decimal DetailPrice { get; set; }
        public int DetailQuantity { get; set; }
        public Orders Order { get; set; }
    }
}
