using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECTemplate.Domain.Entities
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }
        public int DetailOrderId { get; set; }
        public int DetailProductId { get; set; }
        public decimal DetailPrice { get; set; }
        public int DetailQuantity { get; set; }
    }
}
