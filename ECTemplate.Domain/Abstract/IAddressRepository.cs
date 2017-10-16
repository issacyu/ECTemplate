using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IAddressRepository
    {
        IEnumerable<Addresses> Addresses { get; }

        void AddShippingAddress(Addresses shippingAddress);

        void UpdateShippingAddress(int userId, Addresses shippingAddress);

        Addresses FindAddress(int userId);
    }
}
