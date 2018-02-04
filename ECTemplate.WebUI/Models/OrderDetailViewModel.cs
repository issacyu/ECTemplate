using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the order detail info.
    /// </summary>
    public class OrderDetailViewModel
    {
        /// <summary>
        /// A default constructor that uses to initialize the collections.
        /// </summary>
        public OrderDetailViewModel()
        {
            OrderDetails = new List<OrderDetails>();
            ProductDetails = new Dictionary<int, string>();
            Order = new Orders();
        }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public IList<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the product details.
        /// </summary>
        public IDictionary<int, string> ProductDetails { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Orders Order { get; set; }

        /// <summary>
        /// Compute the total from the shopping cart.
        /// </summary>
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