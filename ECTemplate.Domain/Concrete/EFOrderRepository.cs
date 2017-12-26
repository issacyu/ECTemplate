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

        public IEnumerable<Accounts> Accounts => context.Accounts;

        IOrderDetailRepository OrderDetailRepository { get; set; }

        public EFOrderRepository() { }

        public EFOrderRepository(IOrderDetailRepository orderDetailRepository)
        {
            OrderDetailRepository = orderDetailRepository;
        }

        public void AddOrder(int userId, Cart cart, Addresses shippingDetails)
        {

            Orders dbEntry = new Orders()
            {
                OrderId = Guid.NewGuid(),
                OrderAmount = 1,
                OrderShipAddress = shippingDetails.ShippingAddress,
                OrderShipAddress2 = shippingDetails.ShippingAddress2,
                OrderCity = shippingDetails.ShippingCity,
                OrderState = shippingDetails.ShippingState,
                OrderZip = shippingDetails.ShippingZip,
                OrderCountry = shippingDetails.ShippingCountry,
                OrderPhone = shippingDetails.ShippingPhone,
                OrderDate = DateTime.Now,
                OrderStatus = 0
            };

            Accounts account = Accounts.Where(a => a.UserId == userId).FirstOrDefault();
            if (account.Orders == null)
                account.Orders = new List<Orders>();

            OrderDetailRepository.AddOrderDetail(dbEntry, cart);
            account.Orders.Add(dbEntry);
            context.SaveChanges();
        }

        public IEnumerable<Orders> GetOrder(int userId)
        {
           return Orders.Where(o => Equals(o.OrderAccount, userId)).ToList();
        }
    }
}
