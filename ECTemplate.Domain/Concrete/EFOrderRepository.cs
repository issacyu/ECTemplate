using System;
using System.Linq;
using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Orders> Orders => context.Orders;

        public Orders AddOrder(int orderUserId, Cart cart, Addresses shippingDetails)
        {
            Orders dbEntry = new Orders()
            {
                OrderId = 1,
                OrderUserId = orderUserId,
                OrderAmount = 1,
                OrderShipAddress = shippingDetails.ShippingAddress,
                OrderShipAddress2 = shippingDetails.ShippingAddress2,
                OrderCity = shippingDetails.ShippingCity,
                OrderState = shippingDetails.ShippingState,
                OrderZip = shippingDetails.ShippingZip,
                OrderCountry = shippingDetails.ShippingCountry,
                OrderDate = DateTime.Now,
                OrderShipped = 0
            };

            context.Orders.Add(dbEntry);
            context.SaveChanges();

            return dbEntry;
        }

        public IEnumerable<Orders> GetOrder(int userId)
        {
           return Orders.Where(o => Equals(o.OrderUserId, userId)).ToList();
        }
    }
}
