using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> Orders { get; }

        IEnumerable<Accounts> Accounts { get; }

        void AddOrder(int userId, Cart cart, Addresses shippingDetails);

        IEnumerable<Orders> GetOrder(int userId);
    }
}
