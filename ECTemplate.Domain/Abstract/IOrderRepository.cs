using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> Orders { get; }

        Orders AddOrder(int orderUserId, Cart cart, Addresses shippingDetails);

        IEnumerable<Orders> GetOrder(int userId);
    }
}
