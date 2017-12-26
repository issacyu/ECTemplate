using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECTemplate.Domain.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OrderId { get; set; }
        public double OrderAmount { get; set; }
        public string OrderShipAddress { get; set; }
        public string OrderShipAddress2 { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderZip { get; set; }
        public string OrderCountry { get; set; }
        public string OrderPhone { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        [ForeignKey("Account")]
        public int OrderAccount { get; set; }
        public Accounts Account { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
