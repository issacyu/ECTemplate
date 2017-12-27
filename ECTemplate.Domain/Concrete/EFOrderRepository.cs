using System;
using System.Linq;
using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The repository class that implements the IOrderRepository interface and uses an instance of
    /// EFDbContext to retrieve data from the database using the Entity Framework.
    /// </summary>
    public class EFOrderRepository : IOrderRepository
    {
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EFOrderRepository()
        {
            Context = new EFDbContext();
        }

        /// <summary>
        /// An argument constructor that uses to get the IOrderDetailRepository instance 
        /// from the dependency injector.
        /// </summary>
        /// <param name="orderDetailRepository">The IOrderDetailRepository instance.</param>
        public EFOrderRepository(IOrderDetailRepository orderDetailRepository)
        {
            OrderDetailRepository = orderDetailRepository;
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        private EFDbContext Context { get; set; }

        /// <summary>
        /// Gets the order collection.
        /// </summary>
        public IEnumerable<Orders> Orders => Context.Orders;

        /// <summary>
        /// Gets the account collection.
        /// </summary>
        public IEnumerable<Accounts> Accounts => Context.Accounts;

        /// <summary>
        /// Gets or sets the OrderDetailRepository instance.
        /// </summary>
        IOrderDetailRepository OrderDetailRepository { get; set; }

        /// <summary>
        /// Add the order into the database.
        /// </summary>
        /// <param name="userId">The user ID that relates to the order.</param>
        /// <param name="cart">The shopping cart that relates to the order.</param>
        /// <param name="shippingDetails">The shipping detail that relates to the order.</param>
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
            Context.SaveChanges();
        }

        /// <summary>
        /// Find the order in the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to find the order.</param>
        /// <returns>The order.</returns>
        public IEnumerable<Orders> FindOrder(int userId)
        {
           return Orders.Where(o => Equals(o.OrderAccount, userId)).ToList();
        }
    }
}
