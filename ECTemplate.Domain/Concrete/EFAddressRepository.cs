using System.Collections.Generic;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFAddressRepository : IAddressRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Addresses> Addresses => context.Addresses;

        public void AddShippingAddress(Addresses shippingAddress)
        {
            Addresses dbEntry = new Addresses()
            {
                AddressId = shippingAddress.AddressId,
                UserId = shippingAddress.UserId,
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

            context.Addresses.Add(dbEntry);
            context.SaveChanges();
        }

        public void UpdateShippingAddress(Addresses shippingAddress)
        {
            Addresses dbEntry = FindAddress(shippingAddress.UserId);
            if(dbEntry == null)
            {
                context.Addresses.Add(shippingAddress);
            }
            else
            {
                dbEntry.ShippingFirstName = shippingAddress.ShippingFirstName;
                dbEntry.ShippingLastName = shippingAddress.ShippingLastName;
                dbEntry.ShippingAddress = shippingAddress.ShippingAddress;
                dbEntry.ShippingAddress2 = shippingAddress.ShippingAddress2;
                dbEntry.ShippingCity = shippingAddress.ShippingCity;
                dbEntry.ShippingState = shippingAddress.ShippingState;
                dbEntry.ShippingZip = shippingAddress.ShippingZip;
                dbEntry.ShippingCountry = shippingAddress.ShippingCountry;
                dbEntry.ShippingPhone = shippingAddress.ShippingPhone;
            }
            context.SaveChanges();
        }

        public Addresses FindAddress(int userId)
        {
            return Addresses.FirstOrDefault(a => Equals(a.UserId, userId));
        }
    }
}
