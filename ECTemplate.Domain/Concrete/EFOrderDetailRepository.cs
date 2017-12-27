using System;
using System.Collections.Generic;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The repository class that implements the IOrderDetailRepository interface and uses an instance of
    /// EFDbContext to retrieve data from the database using the Entity Framework.
    /// </summary>
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EFOrderDetailRepository()
        {
            Context = new EFDbContext();
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        private EFDbContext Context { get; set; }

        /// <summary>
        /// Gets the order detail collection.
        /// </summary>
        public IEnumerable<OrderDetails> OrderDetails => Context.OrderDetails;

        /// <summary>
        /// Add the order detail into the database.
        /// </summary>
        /// <param name="order">Use the order ID of this order as the foreign key of the order details.</param>
        /// <param name="cart">The shopping cart that contains the order detail.</param>
        public void AddOrderDetail(Orders order, Cart cart)
        {
            if (order.OrderDetails == null)
                order.OrderDetails = new List<OrderDetails>();

            foreach (CartLine cl in cart.Lines)
            {
                OrderDetails orderDetail = new OrderDetails()
                {
                    DetailId = 0,
                    DetailOrderId = order.OrderId,
                    DetailProductId = cl.Product.ProductID,
                    DetailPrice = cl.Product.Price,
                    DetailQuantity = cl.Quantity
                };

                order.OrderDetails.Add(orderDetail);
            }
        }

        /// <summary>
        /// Find the order detail in the database.
        /// </summary>
        /// <param name="orderId">The order ID that uses to find the order detail.</param>
        /// <returns></returns>
        public IEnumerable<OrderDetails> FindOrderDetails(Guid orderId)
        {
            return OrderDetails.Where(od => Equals(od.DetailOrderId, orderId)).ToList();
        }
    }
}
