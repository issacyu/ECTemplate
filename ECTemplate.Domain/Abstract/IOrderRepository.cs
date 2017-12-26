using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    /// <summary>
    /// The class that depends on the IOrderRepository interface can obtain Order
    /// objects without needing to know anything about where they are coming from 
    /// or how the implementation class will deliver them.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets the order collection.
        /// </summary>
        IEnumerable<Orders> Orders { get; }

        /// <summary>
        /// Add the order into a specific user account.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="cart">The shopping cart of the user.</param>
        /// <param name="shippingDetails">The shipping address of the user.</param>
        void AddOrder(int userId, Cart cart, Addresses shippingDetails);

        /// <summary>
        /// Gets all the orders by the user ID.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The order collecton that relates to the user ID.</returns>
        IEnumerable<Orders> GetOrder(int userId);
    }
}
