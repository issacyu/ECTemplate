using System;
using System.Collections.Generic;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<OrderDetails> OrderDetails => context.OrderDetails;

        public void AddOrderDetail(Orders order, Cart cart)
        {
            if (order.OrderDetails == null)
                order.OrderDetails = new List<OrderDetails>();

            foreach (CartLine cl in cart.Lines)
            {
                OrderDetails orderDetail = new OrderDetails()
                {
                    DetailId = 0,
                    DetailOrderId = order.OrderId,
                    DetailProductId = cl.Product.ProductID,
                    DetailPrice = cl.Product.Price,
                    DetailQuantity = cl.Quantity
                };

                order.OrderDetails.Add(orderDetail);
            }
        }

        public IEnumerable<OrderDetails> GetOrderDetails(Guid orderId)
        {
            return OrderDetails.Where(od => Equals(od.DetailOrderId, orderId)).ToList();
        }
    }
}
