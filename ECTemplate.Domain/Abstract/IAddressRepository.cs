using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    /// <summary>
    /// The class that depends on the IAddressRepository interface can obtain Address
    /// objects without needing to know anything about where they are coming from 
    /// or how the implementation class will deliver them.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Gets the address collection.
        /// </summary>
        IEnumerable<Addresses> Addresses { get; }

        /// <summary>
        /// Add the shipping address into the database.
        /// </summary>
        /// <param name="shippingAddress">The shipping address that needs to be added.</param>
        void AddShippingAddress(Addresses shippingAddress);

        /// <summary>
        /// Update an existing shipping address in the database.
        /// </summary>
        /// <param name="userId">The user ID that relates to the shipping address.</param>
        /// <param name="shippingAddress">The new shipping address information.</param>
        void UpdateShippingAddress(int userId, Addresses shippingAddress);

        /// <summary>
        /// Find the shipping address from the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to find the address.</param>
        /// <returns></returns>
        Addresses FindAddress(int userId);
    }
}
