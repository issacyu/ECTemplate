using System.Collections.Generic;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The repository class that implements the IAddressRepository interface and uses an instance of
    /// EFDbContext to retrieve data from the database using the Entity Framework.
    /// </summary>
    public class EFAddressRepository : IAddressRepository
    {
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EFAddressRepository()
        {
            Context = new EFDbContext();
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        private EFDbContext Context { get; set; }

        /// <summary>
        /// Gets the address collection.
        /// </summary>
        public IEnumerable<Addresses> Addresses => Context.Addresses;

        /// <summary>
        /// Add the shipping address into the database.
        /// </summary>
        /// <param name="shippingAddress">The shipping address that uses to add into the database.</param>
        public void AddShippingAddress(Addresses shippingAddress)
        {
            Addresses dbEntry = new Addresses()
            {
                AddressId = shippingAddress.AddressId,
                ShippingFirstName = shippingAddress.ShippingFirstName,
                ShippingLastName = shippingAddress.ShippingLastName,
                ShippingAddress = shippingAddress.ShippingAddress,
                ShippingAddress2 = shippingAddress.ShippingAddress2,
                ShippingCity = shippingAddress.ShippingCity,
                ShippingState = shippingAddress.ShippingState,
                ShippingZip = shippingAddress.ShippingZip,
                ShippingCountry = shippingAddress.ShippingCountry,
                ShippingPhone = shippingAddress.ShippingPhone
            };

            Context.Addresses.Add(dbEntry);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update an existing shipping address in the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to look for the shipping address.</param>
        /// <param name="shippingAddress">The shipping address that needs to be updated.</param>
        public void UpdateShippingAddress(int userId, Addresses shippingAddress)
        {
            Addresses dbEntry = FindAddress(userId);

            dbEntry.ShippingFirstName = shippingAddress.ShippingFirstName;
            dbEntry.ShippingLastName = shippingAddress.ShippingLastName;
            dbEntry.ShippingAddress = shippingAddress.ShippingAddress;
            dbEntry.ShippingAddress2 = shippingAddress.ShippingAddress2;
            dbEntry.ShippingCity = shippingAddress.ShippingCity;
            dbEntry.ShippingState = shippingAddress.ShippingState;
            dbEntry.ShippingZip = shippingAddress.ShippingZip;
            dbEntry.ShippingCountry = shippingAddress.ShippingCountry;
            dbEntry.ShippingPhone = shippingAddress.ShippingPhone;

            Context.SaveChanges();
        }

        /// <summary>
        /// Find the address in the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to find the address.</param>
        /// <returns>The address.</returns>
        public Addresses FindAddress(int userId)
        {
            return Context.Accounts.Include("Address").FirstOrDefault(a => a.UserId == userId).Address;
        }
    }
}
