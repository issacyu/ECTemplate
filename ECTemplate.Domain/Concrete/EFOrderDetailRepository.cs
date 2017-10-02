using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<OrderDetails> OrderDetails => context.OrderDetails;

        public void AddOrderDetail(int orderId, Cart cart)
        {
            foreach(CartLine cl in cart.Lines)
            {
                OrderDetails orderDetail = new OrderDetails()
                {
                    DetailId = 0,
                    DetailOrderId = orderId,
                    DetailProductId = cl.Product.ProductID,
                    DetailPrice = cl.Product.Price,
                    DetailQuantity = cl.Quantity
                };
                context.OrderDetails.Add(orderDetail);
            }

            context.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetOrderDetails(int orderId)
        {
            return OrderDetails.Where(od => Equals(od.DetailOrderId, orderId)).ToList();
        }
    }
}
