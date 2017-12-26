using System;
using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    /// <summary>
    /// The class that depends on the IOrderDetailRepository interface can obtain OrderDetail
    /// objects without needing to know anything about where they are coming from 
    /// or how the implementation class will deliver them.
    /// </summary>
    public interface IOrderDetailRepository
    {
        /// <summary>
        /// Gets the order detail collection.
        /// </summary>
        IEnumerable<OrderDetails> OrderDetails { get; }

        /// <summary>
        /// Add the order detail into the database.
        /// </summary>
        /// <param name="order">The order that relates to the order details.</param>
        /// <param name="cart">The shopping cart that conatains the order details.</param>
        void AddOrderDetail(Orders order, Cart cart);

        IEnumerable<OrderDetails> GetOrderDetails(Guid orderId);
    }
}
