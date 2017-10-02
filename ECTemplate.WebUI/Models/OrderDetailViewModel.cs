using System.Collections.Generic;

using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    public class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
            OrderDetails = new List<OrderDetails>();
            ProductDetails = new Dictionary<int, string>();
            Order = new Orders();
        }
        public IList<OrderDetails> OrderDetails { get; set; }
        public IDictionary<int, string> ProductDetails { get; set; }
        public Orders Order { get; set; }
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach(var orderDetail in OrderDetails)
                {
                    total += orderDetail.DetailPrice * orderDetail.DetailQuantity;
                }
                return total;
            }
        }
    }
}